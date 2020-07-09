namespace Common.News.Dto.Requests
{
    /// <summary>
    /// Запрос для оценки новости.
    /// </summary>
    public sealed class LikeRequest
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// Id Новости.
        /// </summary>
        public int IdNews { get; set; }
    }
}
