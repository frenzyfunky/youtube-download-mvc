using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Application.UseCases;

namespace YoutubeMp3Downloader.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private readonly IDownloadUseCase _downloadUseCase;

        public DownloadController(IDownloadUseCase downloadUseCase)
        {
            _downloadUseCase = downloadUseCase;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Download(string id)
        {
            var result = await _downloadUseCase.DownloadAudio(id);

            using (result)
            {
                try
                {
                    var fileContents = result.Stream.ToArray();
                    return File(fileContents, result.MimeType, result.FileName, true);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }
    }
}
