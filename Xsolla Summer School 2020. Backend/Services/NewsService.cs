using Common.News.Dto;
using Common.News.Dto.Requests;
using Common.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xsolla_Summer_School_2020._Backend.Infrastructure;
using Xsolla_Summer_School_2020._Backend.Interfaces;

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
        public async Task<NewsDto> AddNewsAsync(AddNewsRequest request)
        {
            await _context.News.AddAsync(MaptoDto(request));
            await _context.SaveChangesAsync();

            return MaptoDto(request);
        }

        /// <inheritdoc/>
        public async Task<NewsDto[]> GetMostPopularNewsAsync()
        {
            return await _context.News.OrderByDescending(x => x.Rating).ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<NewsDto[]> GetNewsAsync()
        {
            return await _context.News.ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<NewsDto[]> GetNewsCategoryAsync(NewsByCategoryRequest request)
        {
            return await _context.News.Where(x => x.IdCategory == request.IdCategory).ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<NewsDto> LikeNewsAsync(LikeRequest request)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.IdNews == request.IdNews);
            var userNews = await _context.UserLikesNews.FirstOrDefaultAsync(x => x.IdNews == request.IdNews && x.IdUser == request.IdUser);
            if (userNews == null)
            {
                await _context.UserLikesNews.AddAsync(new UserLikesNewsDto
                {
                    IdNews = request.IdNews,
                    IdUser = request.IdUser,
                    Like = true,
                });
                news.Rating += 1;
            }
            else
            {
                userNews.Like = !userNews.Like;
                news.Rating += userNews.Like ? 1 : -1;
                _context.UserLikesNews.Update(userNews);
            }

            await _context.SaveChangesAsync();

            return news;
        }

        /// <inheritdoc/>
        public async Task<NewsDto> RemoveLikeNewsAsync(LikeRequest request)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.IdNews == request.IdNews);
            var userNews = await _context.UserLikesNews.FirstOrDefaultAsync(x => x.IdNews == request.IdNews && x.IdUser == request.IdUser);
            _context.UserLikesNews.Remove(userNews);

            if (userNews.Like)
            {
                news.Rating -= 1;
                _context.Update(news);
            }

            await _context.SaveChangesAsync();

            return news;
        }

        /// <inheritdoc/>
        public async Task<NewsDto> RemoveNewsAsync(RemoveNewsRequest request)
        {
            var News = await _context.News.FirstOrDefaultAsync(x => x.IdNews == request.IdNews);
            _context.News.Remove(News);
            await _context.SaveChangesAsync();

            return News;
        }

        /// <inheritdoc/>
        public async Task<NewsDto> UpdateNewsAsync(UpdateNewsRequest request)
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
