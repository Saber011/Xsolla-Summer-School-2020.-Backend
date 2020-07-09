using Common.News.Dto;
using Common.News.Dto.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xsolla_Summer_School_2020._Backend.Infrastructure;
using Xsolla_Summer_School_2020._Backend.Interfaces;
using Xsolla_Summer_School_2020._Backend.Services;

namespace Xsolla_Summer_School_2020._Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _service;
        private readonly ExecuteService _executeService;
        public NewsController(INewsService service, ExecuteService executeService)
        {
            _service = service;
            _executeService = executeService;
        }

        /// <summary>
        /// Получить новости.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpGet("GetNews")]
        public async Task<ServiceResponse<NewsDto[]>> GetNews()
        {
            return await _executeService.TryExecute(() => _service.GetNewsAsync());
        }

        /// <summary>
        /// Обновить новость.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPut("UpdateNews")]
        public async Task<ServiceResponse<NewsDto>> UpdateNews(UpdateNewsRequest request)
        {
            return await _executeService.TryExecute(() => _service.UpdateNewsAsync(request));
        }

        /// <summary>
        /// Удалить новость.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpDelete("RemoveNews")]
        public async Task<ServiceResponse<NewsDto>> RemoveNews(RemoveNewsRequest request)
        {
            return await _executeService.TryExecute(() => _service.RemoveNewsAsync(request));
        }

        /// <summary>
        /// Лайкнуть новость.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPut("LikeNews")]
        public async Task<ServiceResponse<NewsDto>> LikeNews(LikeRequest request)
        {
            return await _executeService.TryExecute(() => _service.LikeNewsAsync(request));
        }

        /// <summary>
        /// Добавить новость.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPost("AddNews")]
        public async Task<ServiceResponse<NewsDto>> AddNews(AddNewsRequest request)
        {
            return await _executeService.TryExecute(() => _service.AddNewsAsync(request));
        }

        /// <summary>
        /// Получить самые популярные новости.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPost("GetMostPopularNews")]
        public async Task<ServiceResponse<NewsDto[]>> GetMostPopularNews()
        {
            return await _executeService.TryExecute(() => _service.GetMostPopularNewsAsync());
        }

        /// <summary>
        /// Удалить оценку новости.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code = "401" > Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPost("RemoveLikes")]
        public async Task<ServiceResponse<NewsDto>> RemoveLikesNews(LikeRequest request)
        {
            return await _executeService.TryExecute(() => _service.RemoveLikeNewsAsync(request));
        }

        /// <summary>
        /// Получить все новости в категории.
        /// </summary>
        /// <response code = "200" > Успешное выполнение.</response>
        /// <response code = "204" > Контент не найден</response>
        /// <response code="401">Данный запрос требует аутентификации.</response>
        /// <response code = "500" > Непредвиденная ошибка сервера.</response>
        [HttpPost("GetNewsByCategory")]
        public async Task<ServiceResponse<NewsDto[]>> RemoveLikesNews(NewsByCategoryRequest request)
        {
            return await _executeService.TryExecute(() => _service.GetNewsCategoryAsync(request));
        }
    }
}
