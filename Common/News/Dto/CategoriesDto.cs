using System.ComponentModel.DataAnnotations;

namespace Common.News.Dto
{
    /// <summary>
    /// Категории новостей.
    /// </summary>
    public sealed class CategoriesDto
    {
        /// <summary>
        /// id категории.
        /// </summary>
        [Key]
        public int IdCategory { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public string Category { get; set; }
    }
}
