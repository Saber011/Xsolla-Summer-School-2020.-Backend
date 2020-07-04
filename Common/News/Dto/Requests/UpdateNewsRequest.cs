using System.ComponentModel.DataAnnotations;

namespace Common.News.Dto.Requests
{
    /// <summary>
    /// Запрос на обновление новости.
    /// </summary>
    public sealed class UpdateNewsRequest
    {
        /// <summary>
        /// Id новости.
        /// </summary>
        public int IdNews { get; set; }

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
        /// Id категории.
        /// </summary>
        public int IdCategory { get; set; }
    }
}
