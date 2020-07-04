using System.ComponentModel.DataAnnotations;

namespace Common.Users.Dto.Requests
{
    /// <summary>
    /// Запрос пользователя.
    /// </summary>
    public sealed class UserModelRequest
    {
        /// <summary>
        /// ID юзера.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Никнейм юзера.
        /// </summary>
        [Required]
        public string Login { get; set; }
    }
}
