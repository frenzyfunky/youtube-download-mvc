using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeMp3Downloader.Service.Repository;
using YoutubeMp3Downloader.Shared.Model;

namespace YoutubeMp3Downloader.Infrastructure.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public SearchRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<SearchResponse> Search(string queryString)
        {
            var client = _clientFactory.CreateClient("YoutubeApi");

            try
            {
                var response = await client.GetAsync($"?{queryString}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SearchResponse>(content);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
