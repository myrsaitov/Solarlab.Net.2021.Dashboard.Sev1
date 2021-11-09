using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Sev1.UserFiles.Contracts.Contracts.YandexDisk;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Sev1.UserFiles.Contracts.ApiClients.YandexDisk
{
    /// <summary>
    /// API-клиент Яндекс-Диска
    /// </summary>
    public class YandexDiskApiClient : IYandexDiskApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public YandexDiskApiClient(
            HttpClient httpClient,
            IConfiguration configuration
            )
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        /// <summary>
        /// Загружает файл в облако
        /// </summary>
        /// <param name="data">Файл</param>
        /// <returns></returns>
        public async Task<string> Upload(IFormFile data)
        {
            var uploadUrl = await GetUploadUrl(data.FileName);
            var result = await _httpClient.PutAsync(new Uri(uploadUrl.Href), new StreamContent(data.OpenReadStream()));
            result.EnsureSuccessStatusCode();

            var downloadUrl = await GetDownloadUrl(data.FileName);
            return downloadUrl.Href;
        }

        /// <summary>
        /// Возвращает URL для загрузки в облако
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async Task<GetUploadUrlResponse> GetUploadUrl(string fileName)
        {
            var BasePath = _configuration["YandexDisk:BasePath"];
            var OAuthValue = _configuration["YandexDisk:OAuthValue"];
            var url = $"resources/upload?path={BasePath}{fileName}";
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("OAuth", OAuthValue);
            var result = await _httpClient.GetAsync(HttpUtility.HtmlEncode(url));
            result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetUploadUrlResponse>(await result.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Возвращает URL для скачивания из облака
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async Task<GetUploadUrlResponse> GetDownloadUrl(string fileName)
        {
            var BasePath = _configuration["YandexDisk:BasePath"];
            var url = $"resources/download?path={BasePath}{fileName}";
            var result = await _httpClient.GetAsync(HttpUtility.HtmlEncode(url));
            result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetUploadUrlResponse>(await result.Content.ReadAsStringAsync());
        }
    }
}