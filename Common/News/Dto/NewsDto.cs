using System.ComponentModel.DataAnnotations;

namespace Common.News.Dto
{
    /// <summary>
    /// Новости.
    /// </summary>
    public sealed class NewsDto
    {
        /// <summary>
        /// Id новости.
        /// </summary>
        [Key]
        public int IdNews { get; set; }

        /// <summary>
        /// Id категории.
        /// </summary>
        public int IdCategory { get; set; }

        /// <summary>
        /// Заголовок новости.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Описание новости.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Рейтинг новости.
        /// </summary>
        public int Rating { get; set; }
    }
}
