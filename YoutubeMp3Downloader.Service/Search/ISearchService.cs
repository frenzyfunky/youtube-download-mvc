using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Service.Search
{
    public interface ISearchService
    {
        Task<SearchResponse> Search(Dictionary<string, string> queryParams);
    }
}
