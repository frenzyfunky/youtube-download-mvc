using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;
using YoutubeMp3Downloader.Service.Repository;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Infrastructure.Repository
{
    public class DownloadRepository : IDownloadRepository
    {
        public async Task<YoutubeStreamModel> DownloadAudio(string videoId)
        {
            var youtube = new YoutubeClient();
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
            var audioStreamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            var mimeType = $"audio/{audioStreamInfo.Container.Name}";
            var fileName = $"{videoId}.{audioStreamInfo.Container.Name}";

            //var streamInfos = new IStreamInfo[] { audioStreamInfo };

            //await youtube.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder($"{videoId}.mp3").Build());
            var stream = new MemoryStream();
            await youtube.Videos.Streams.CopyToAsync(audioStreamInfo, stream);

            var result = new YoutubeStreamModel
            {
                Stream = stream,
                FileName = fileName,
                MimeType = mimeType
            };

            return result;
        }
    }
}
