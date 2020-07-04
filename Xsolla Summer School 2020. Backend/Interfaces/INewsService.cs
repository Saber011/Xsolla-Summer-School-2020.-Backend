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
        public Task<NewsDto[]> GetNews();

        /// <summary>
        /// Добавление новостей.
        /// </summary>
        /// <returns></returns>
        public Task<NewsDto> AddNews(AddNewsRequest request);

        /// <summary>
        /// Удаление новостей.
        /// </summary>
        public Task<NewsDto> RemoveNews(RemoveNewsRequest request);

        /// <summary>
        /// Обновление новостей.
        /// </summary>
        public Task<NewsDto> UpdateNews(UpdateNewsRequest request);

        /// <summary>
        /// Лайк новости.
        /// </summary>
        public Task<NewsDto> LikeNews(LikeRequest request);
    }
}
