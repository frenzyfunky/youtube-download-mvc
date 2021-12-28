using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeMp3Downloader.Application.UseCases;
using YoutubeMp3Downloader.Infrastructure.Repository;
using YoutubeMp3Downloader.Service.Repository;
using YoutubeMp3Downloader.Service.Search;
using YoutubeMp3Downloader.Service.Download;

namespace YoutubeMp3Downloader.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddYoutubeServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("YoutubeApi", options =>
            {
                options.BaseAddress = new Uri(configuration["Youtube:Url"]);
            });

            services.AddTransient<ISearchService, YoutubeSearchService>();
            services.AddTransient<ISearchRepository, SearchRepository>();
            services.AddTransient<ISearchUseCase, SearchUseCase>();
            services.AddTransient<IDownloadService, DownloadService>();
            services.AddTransient<IDownloadRepository, DownloadRepository>();
            services.AddTransient<IDownloadUseCase, DownloadUseCase>();
            return services;
        }
    }
}
