using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Service.Repository;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Service.Download
{
    public class DownloadService : IDownloadService
    {
        private readonly IDownloadRepository _repository;

        public DownloadService(IDownloadRepository repository)
        {
            _repository = repository;
        }
        public async Task<YoutubeStreamModel> DownloadAudio(string videoId)
        {
            return await _repository.DownloadAudio(videoId);
        }
    }
}
