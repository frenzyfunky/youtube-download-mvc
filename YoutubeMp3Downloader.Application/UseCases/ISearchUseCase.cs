using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Application.UseCases
{
    public interface ISearchUseCase
    {
        Task<SearchResponse> Search(SearchModel model);
    }
}
