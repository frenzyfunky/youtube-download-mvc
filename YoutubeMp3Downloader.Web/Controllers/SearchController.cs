using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Application.UseCases;
using YoutubeMp3Downloader.Shared.Model;
using YoutubeMp3Downloader.Web.Models;
using YoutubeMp3Downloader.Web.Utilities;

namespace YoutubeMp3Downloader.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchUseCase _searchUseCase;
        private readonly IViewRenderService _viewRenderService;

        public SearchController(ISearchUseCase searchUseCase, IViewRenderService viewRenderService)
        {
            _searchUseCase = searchUseCase;
            _viewRenderService = viewRenderService;
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Get([FromBody] SearchModel model)
        {
            if (model is null || (string.IsNullOrEmpty(model.q) && string.IsNullOrEmpty(model.pageToken)))
            {
                return BadRequest();
            }

            var result = await _searchUseCase.Search(model);

            if (result is null)
            {
                return NotFound(new ApiResponse<SearchResponse>("Not found"));
            }

            var view = await _viewRenderService.RenderToStringAsync("Search/Search", result);

            var apiResponse = new ApiResponse<string>()
            {
                Data = view,
                IsSuccess = true
            };

            return Ok(apiResponse);
        }
    }
}
