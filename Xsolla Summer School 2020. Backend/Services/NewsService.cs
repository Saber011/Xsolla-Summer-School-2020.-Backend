using Common.News.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xsolla_Summer_School_2020._Backend.Infrastructure;
using Xsolla_Summer_School_2020._Backend.Interfaces;
using Common.News.Dto.Requests;
using Common.Users.Dto;

namespace Xsolla_Summer_School_2020._Backend.Services
{
    /// <inheritdoc/>
    public sealed class NewsService : INewsService
    {
        private readonly ApplicationContext _context;

        public NewsService(ApplicationContext _applicationContext)
        {
            _context = _applicationContext;
        }

        /// <inheritdoc/>
        public async Task<NewsDto> AddNews(AddNewsRequest request)
        {
             await _context.News.AddAsync(MaptoDto(request));
             await _context.SaveChangesAsync();

            return MaptoDto(request);
        }

        /// <inheritdoc/>
        public async Task<NewsDto[]> GetNews()
        {
            return await _context.News.ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<NewsDto> LikeNews(LikeRequest request)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.IdNews == request.IdNews);
            var userNews = await _context.UserLikesNews.FirstOrDefaultAsync(x => x.IdNews == request.IdNews);
            var likeNews = userNews ?? new UserLikesNews()
            {
                IdUser = request.IdUser,
                IdNews = request.IdNews,
                Like = request.Like
            };
            if (userNews == null)
            {
                await _context.AddAsync(likeNews);
            }

            news.Rating += request.Like && likeNews.Like ? 1 : -1;
            
            _context.News.Update(news);
            await _context.SaveChangesAsync();

            return news;
        }

        /// <inheritdoc/>
        public async Task<NewsDto> RemoveNews(RemoveNewsRequest request)
        {
            var News = await _context.News.FirstOrDefaultAsync(x => x.IdNews == request.IdNews);
            _context.News.Remove(News);
            await _context.SaveChangesAsync();

            return News;
        }

        /// <inheritdoc/>
        public async Task<NewsDto> UpdateNews(UpdateNewsRequest request)
        {
            var News = await _context.News.FirstOrDefaultAsync(x => x.IdNews == request.IdNews);
            _context.News.Update(News);
            await _context.SaveChangesAsync();

            return News;
        }

        private NewsDto MaptoDto(AddNewsRequest request)
        {
            return new NewsDto
            {
                IdCategory = request.IdCategory,
                Title = request.Title,
                Description = request.Description,
                Rating = request.Rating,
            };
        }
    }
}
