using Common.News.Dto;
using Common.News.Dto.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xsolla_Summer_School_2020._Backend.Interfaces;

namespace Xsolla_Summer_School_2020._Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _service;
        public NewsController(INewsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить новости.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpGet("GetNews")]
        public async Task<NewsDto[]> GetNews()
        {
            return await _service.GetNews();
        }

        /// <summary>
        /// Обновить новость.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPut("UpdateNews")]
        public async Task<NewsDto> UpdateNews(UpdateNewsRequest request)
        {
            return await _service.UpdateNews(request);
        }

        /// <summary>
        /// Удалить новость.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpDelete("RemoveNews")]
        public async Task<NewsDto> RemoveNews(RemoveNewsRequest request)
        {
            return await _service.RemoveNews(request);
        }

        /// <summary>
        /// Лайкнуть новость.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPut("LikeNews")]
        public async Task<NewsDto> LikeNews(LikeRequest request)
        {
            return await _service.LikeNews(request);
        }

        /// <summary>
        /// Добавить новость.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPost("AddNews")]
        public async Task<NewsDto> AddNews(AddNewsRequest request)
        {
            return await _service.AddNews(request);
        }
    }
}
