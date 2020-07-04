namespace Common.News.Dto.Requests
{
    /// <summary>
    /// Запрос на удаление новости.
    /// </summary>
    public sealed class RemoveNewsRequest
    {
        /// <summary>
        /// Id новости.
        /// </summary>
        public int IdNews { get; set; }
    }
}
