namespace Common.News.Dto.Requests
{
    /// <summary>
    /// Запрос на получение новостей по категории.
    /// </summary>
    public sealed class NewsByCategoryRequest
    {
        /// <summary>
        /// Id категории.
        /// </summary>
        public int IdCategory { get; set; }
    }
}
