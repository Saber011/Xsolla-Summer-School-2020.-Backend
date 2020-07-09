using System.ComponentModel.DataAnnotations;

namespace Common.Users.Dto
{
    /// <summary>
    /// Журнал просмотренных новостей пользователя.
    /// </summary>
    public sealed class UserLikesNewsDto
    {
        /// <summary>
        /// Id Журнала.
        /// </summary>
        [Key]
        public int IdUserLikesNews { get; set; }

        /// <summary>
        /// ID пользователя.
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// Id новости.
        /// </summary>
        public int IdNews { get; set; }

        /// <summary>
        /// Оценка новости.
        /// </summary>
        public bool Like { get; set; }
    }
}
