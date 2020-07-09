using System.ComponentModel.DataAnnotations;

namespace Common.Users.Dto
{
    /// <summary>
    /// Юзеры
    /// </summary>
    public sealed class UserDto
    {
        /// <summary>
        /// ID юзера
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Никнейм юзера
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Пароль юзера
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
