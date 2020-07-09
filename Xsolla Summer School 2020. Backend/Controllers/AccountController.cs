using Common.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xsolla_Summer_School_2020._Backend.Interfaces;
using Common.Users.Dto.Requests;
using Xsolla_Summer_School_2020._Backend.Services;
using Xsolla_Summer_School_2020._Backend.Infrastructure;

namespace Xsolla_Summer_School_2020._Backend.Controllers
{
    /// <summary>
    /// Api для работы с пользователем
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ExecuteService _executeService;

        public AccountController(IUserService userService, ExecuteService executeService)
        {
            _userService = userService;
            _executeService = executeService;
        }

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name = "id" > Индификтор пользвателя</param>
        /// <returns>Найденный пользватель</returns>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpGet("GetUserById")]
        public async Task<ServiceResponse<UserModelRequest>> GetUser(int id)
        {
            return await _executeService.TryExecute(() => _userService.GetByIdAsync(id));
        }

        /// <summary>
        /// Получить пользователя по логину
        /// </summary>
        /// <param name = "login" > Логин пользвателя</param>
        /// <returns>Найденный пользватель</returns>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [Authorize]
        [HttpGet("GetUserByLogin")]
        public async Task<ServiceResponse<UserModelRequest>> GetUserByLogin(string login)
        {
            return await _executeService.TryExecute(() => _userService.GetUserByLoginAsync(login));
        }

        /// <summary>
        /// Получить всех пользвателей
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpGet("GetAllUsers")]
        public async Task<ServiceResponse<UserModelRequest[]>> GetAllUsers()
        {
            return await _executeService.TryExecute(() => _userService.GetAllUsersAsync());
        }

        /// <summary>
        /// Удалить пользвателя
        /// </summary>
        /// <param name="id">Индефикатор пользователя</param>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [Authorize]
        [HttpDelete("DeleteUser")]
        public async Task<ServiceResponse<UserDto>> DeleteUser(int id)
        {
            return await _executeService.TryExecute(() => _userService.DeleteAsync(id));
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="userRequest">Модель пользователя</param>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ServiceResponse<dynamic>> Login(UserRequest userRequest)
        {
            return await _executeService.TryExecute(() => _userService.Login(userRequest));
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userRequest">Модель пользвателя</param>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ServiceResponse<UserDto>> Register(UserRequest userRequest)
        {
            return await _executeService.TryExecute(() => _userService.CreateAsync(userRequest));
        }

        /// <summary>
        /// Изменить пароль пользователя
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPut("resertPassword")]
        public async Task<ServiceResponse<UserDto>> ResetPassword(ResetPasswordRequest request)
        {
            return await _executeService.TryExecute(() => _userService.ResetPasswordAsync(request.Id, request.NewPasswrod));
        }

    }
}