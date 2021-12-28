using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Service.Search;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Application.UseCases
{
    public class SearchUseCase : ISearchUseCase
    {
        private readonly ISearchService _searchService;

        public SearchUseCase(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public Task<SearchResponse> Search(SearchModel model)
        {
            var dict = model.GetType()
                    .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                    .ToDictionary(prop => prop.Name, prop => (string)prop.GetValue(model, null));

            var notNullDict = (from kv in dict
             where kv.Value != null
             select kv).ToDictionary(kv => kv.Key, kv => kv.Value);

            return _searchService.Search(notNullDict);
        }
    }
}
