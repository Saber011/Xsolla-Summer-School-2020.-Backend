using Common.News.Dto;
using Common.News.Dto.Requests;
using System.Threading.Tasks;

namespace Xsolla_Summer_School_2020._Backend.Interfaces
{
    /// <summary>
    /// Сервис для работы с новостями.
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// Получить все новости.
        /// </summary>
        public Task<NewsDto[]> GetNewsAsync();

        /// <summary>
        /// Добавление новостей.
        /// </summary>
        /// <returns></returns>
        public Task<NewsDto> AddNewsAsync(AddNewsRequest request);

        /// <summary>
        /// Удаление новостей.
        /// </summary>
        public Task<NewsDto> RemoveNewsAsync(RemoveNewsRequest request);

        /// <summary>
        /// Обновление новостей.
        /// </summary>
        public Task<NewsDto> UpdateNewsAsync(UpdateNewsRequest request);

        /// <summary>
        /// Лайк новости.
        /// </summary>
        public Task<NewsDto> LikeNewsAsync(LikeRequest request);

        /// <summary>
        /// Снятие оценки новости новости.
        /// </summary>
        public Task<NewsDto> RemoveLikeNewsAsync(LikeRequest request);

        /// <summary>
        /// Получить самые популярные новости.
        /// </summary>
        public Task<NewsDto[]> GetMostPopularNewsAsync();

        /// <summary>
        /// Получить новость по категории.
        /// </summary>
        public Task<NewsDto[]> GetNewsCategoryAsync(NewsByCategoryRequest request);
    }
}
