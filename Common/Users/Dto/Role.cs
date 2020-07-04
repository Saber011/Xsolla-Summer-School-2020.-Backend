using System.ComponentModel.DataAnnotations;

namespace Common.Users.Dto
{
    /// <summary>
    /// Роли.
    /// </summary>
    public sealed class Role
    {
        /// <summary>
        /// ID роли.
        /// </summary>
        [Key]
        public int IdRole { get; set; }

        /// <summary>
        /// Наименование роли.
        /// </summary>
        [Required]
        public string NameRole { get; set; }
    }
}
