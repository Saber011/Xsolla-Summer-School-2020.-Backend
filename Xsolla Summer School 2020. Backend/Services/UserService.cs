using Common.Users.Dto;
using Common.Users.Dto.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xsolla_Summer_School_2020._Backend.Exceptions;
using Xsolla_Summer_School_2020._Backend.Infrastructure;
using Xsolla_Summer_School_2020._Backend.Interfaces;
using Xsolla_Summer_School_2020._Backend.Security;

namespace Xsolla_Summer_School_2020._Backend.Services
{

    /// <inheritdoc/>
    public sealed class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<UserDto> CreateAsync(UserRequest user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new AppException("Password is required");
            }

            if (_context.Users.Any(x => x.Login == user.Login))
            {
                throw new AppException("Username \"" + user.Login + "\" is already taken");
            }

            user.Password = SecurePasswordHasher.HasFunction(user.Password);
            var userModel = new UserDto() { Login = user.Login, Password = user.Password };

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            var users = await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login);
            await _context.UserRoles.AddAsync(new UserRolesDto { UserId = users.Id, RoleIdRole = 1 });
            await _context.SaveChangesAsync();
            return userModel;
        }

        /// <inheritdoc/>
        public async Task<UserDto> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        /// <inheritdoc/>
        public async Task<UserModelRequest> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return MapToRequest(user);
        }

        /// <inheritdoc/>
        public async Task<UserModelRequest[]> GetAllUsersAsync()
        {
            var users = await _context.Users.ToArrayAsync();

            return MapToArray(users);
        }

        /// <inheritdoc/>
        public async Task<UserDto> ResetPasswordAsync(int id, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new AppException("Не существует пользователя с таким идетификатором");
            }

            user.Password = SecurePasswordHasher.HasFunction(newPassword);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        /// <inheritdoc/>
        public async Task<dynamic> Login(UserRequest request)
        {
            var identity = GetIdentity(request.Login, request.Password);
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTime)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name,
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<UserModelRequest> GetUserByLoginAsync(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);

            return MapToRequest(user);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = _context.Users.FirstOrDefault(x => x.Login == username);

            if (person == null)
            {
                throw new AppException("Invalid username or password");
            }

            var savedPasswordHash = person.Password;
            var hashBytes = Convert.FromBase64String(savedPasswordHash);
            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            var hash = pbkdf2.GetBytes(20);

            for (var i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    throw new AppException("Invalid username or password");
                }
            }
            var firstUserRoles = _context.UserRoles.FirstOrDefault(x => x.UserId == person.Id);
            var roles = _context.Roles.FirstOrDefault(x => x.IdRole == firstUserRoles.RoleIdRole);

            var claims = new List<Claim>
           {
               new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
               new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.NameRole)
           };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        private UserModelRequest MapToRequest(UserDto user)
        {
            return new UserModelRequest
            {
                Login = user.Login,
                Id = user.Id,
            };
        }

        private UserModelRequest[] MapToArray(UserDto[] users)
        {
            return users.Select(x => new UserModelRequest
            {
                Id = x.Id,
                Login = x.Login,
            }).ToArray();
        }

    }
}
