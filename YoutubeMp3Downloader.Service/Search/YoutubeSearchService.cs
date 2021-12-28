using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeMp3Downloader.Service.Repository;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Service.Search
{
    public class YoutubeSearchService : ISearchService
    {
        private readonly IConfiguration _configuration;
        private readonly ISearchRepository _searchRepository;
        private readonly ILogger<YoutubeSearchService> _logger;

        public YoutubeSearchService(IConfiguration configuration, ISearchRepository searchRepository, ILogger<YoutubeSearchService> logger)
        {
            _configuration = configuration;
            _searchRepository = searchRepository;
            _logger = logger;
        }
        public async Task<SearchResponse> Search(Dictionary<string, string> queryParams)
        {
            var apiKey = _configuration["Youtube:ApiKey"];
            queryParams.Add("key", apiKey);
            queryParams.Add("part", "snippet");
            queryParams.Add("maxResults", "25");

            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var param in queryParams)
            {
                query[param.Key] = param.Value;
            }

            try
            {
                var result = await _searchRepository.Search(query.ToString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
