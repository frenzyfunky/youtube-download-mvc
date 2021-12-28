using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YoutubeMp3Downloader.Shared.Model
{
    public class YoutubeStreamModel : IDisposable
    {
        public MemoryStream Stream { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }

        public void Dispose()
        {
            if (Stream != null)
            {
                Stream.Dispose();
            }
        }
    }
}
