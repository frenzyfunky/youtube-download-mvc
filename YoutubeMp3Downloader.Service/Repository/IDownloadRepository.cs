using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Service.Repository
{
    public interface IDownloadRepository
    {
        Task<YoutubeStreamModel> DownloadAudio(string videoId);
    }
}
