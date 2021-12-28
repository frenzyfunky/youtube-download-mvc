using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Service.Download;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Application.UseCases
{
    public class DownloadUseCase : IDownloadUseCase
    {
        private readonly IDownloadService _downloadService;

        public DownloadUseCase(IDownloadService downloadService)
        {
            _downloadService = downloadService;
        }
        public async Task<YoutubeStreamModel> DownloadAudio(string videoId)
        {
            return await _downloadService.DownloadAudio(videoId);
        }
    }
}
