using Common.Users.Dto;
using Common.Users.Dto.Requests;
using System.Threading.Tasks;

namespace Xsolla_Summer_School_2020._Backend.Interfaces
{
    /// <summary>
    /// сервис для работы с пользователями
    /// </summary>
    public interface IUserService
    {

        /// <summary>
        /// Поиск по id
        /// </summary>
        /// <param name="id">Индификатор пользователя</param>
        /// <returns>Возращает пользвателя</returns>
        Task<UserModelRequest> GetByIdAsync(int id);

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user">параметры запроса</param>
        Task<UserDto> CreateAsync(UserRequest user);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Индификатор пользователя</param>
        Task<UserDto> DeleteAsync(int id);

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="id">Индификатор пользователя</param>
        /// <param name="newPassword">Новый пароль</param>
        Task<UserDto> ResetPasswordAsync(int id, string newPassword);

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        Task<UserModelRequest[]> GetAllUsersAsync();

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="request">параметры запроса</param>
        /// <returns>Возращает токен</returns>
        Task<dynamic> Login(UserRequest request);

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="login">логин пользователя</param>
        /// <returns>Возращает токен</returns>
        Task<UserModelRequest> GetUserByLoginAsync(string login);
    }
}
