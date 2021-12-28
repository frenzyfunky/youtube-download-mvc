using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Service.Download
{
    public interface IDownloadService
    {
        Task<YoutubeStreamModel> DownloadAudio(string videoId);
    }
}
