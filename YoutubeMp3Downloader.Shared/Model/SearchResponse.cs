using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeMp3Downloader.Shared.Model
{
    public class SearchResponse
    {
        public string Kind { get; set; }
        public string ETag { get; set; }
        public string NextPageToken { get; set; }
        public string PrevPageToken { get; set; }
        public string RegionCode { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<Resource> Items { get; set; }
    }

    public class Resource
    {
        public string Kind { get; set; }
        public string ETag { get; set; }
        public Id Id { get; set; }
        public Snippet Snippet { get; set; }
    }

    public class Id
    {
        public string Kind { get; set; }
        public string VideoId { get; set; }
        public string ChannelId { get; set; }
        public string PlaylistId { get; set; }
    }

    public class PageInfo
    {
        public int TotalResults { get; set; }
        public int ResultsPerPage { get; set; }
    }

    public class Snippet
    {
        public DateTime PublishedAt { get; set; }
        public string ChannelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Thumbnails Thumbnails { get; set; }
        public string ChannelTitle { get; set; }
        public string LiveBroadcastContent { get; set; }
        public DateTime PublishTime { get; set; }
    }

    public class Thumbnails
    {
        public ThumnailProps Default { get; set; }
        public ThumnailProps Medium { get; set; }
        public ThumnailProps High { get; set; }
    }

    public class ThumnailProps
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
