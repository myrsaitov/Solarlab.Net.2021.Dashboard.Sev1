using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Sev1.UserFiles.Contracts.Contracts.YandexDisk.Responses;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;
using System.IO;

namespace Sev1.UserFiles.Contracts.ApiClients.YandexDisk
{
    /// <summary>
    /// API-клиент Яндекс-Диска
    /// </summary>
    public sealed class YandexDiskApiClient : IYandexDiskApiClient
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
            var uploadUri = await GetUploadUri(data.FileName);
            var result = await _httpClient.PutAsync(new Uri(uploadUri.Href), new StreamContent(data.OpenReadStream()));
            result.EnsureSuccessStatusCode();

            var downloadUri = await GetDownloadUri(data.FileName);
            return downloadUri.Href;
        }

        /// <summary>
        /// Загружает файл в облако
        /// </summary>
        /// <param name="data">Файл</param>
        /// <returns></returns>
        public async Task<string> UploadBase64(UserFileBase64UploadRequest data)
        {
            // Преобразование из base64
            var file = Convert.FromBase64String(data.ContentBase64);

            // Создаем поток
            Stream stream = new MemoryStream(file);

            var uploadUri = await GetUploadUri(data.FileName);
            var result = await _httpClient.PutAsync(
                new Uri(uploadUri.Href),
                new StreamContent(stream));

            result.EnsureSuccessStatusCode();

            var downloadUri = await GetDownloadUri(data.FileName);
            return downloadUri.Href;
        }

        /// <summary>
        /// Возвращает URI для загрузки в облако
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async Task<GetUploadUriResponse> GetUploadUri(string fileName)
        {
            var BasePath = _configuration["YandexDisk:BasePath"];
            var OAuthValue = _configuration["YandexDisk:OAuthValue"];
            var uri = $"resources/upload?path={BasePath}{fileName}";
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("OAuth", OAuthValue);
            var result = await _httpClient.GetAsync(HttpUtility.HtmlEncode(uri));
            result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetUploadUriResponse>(await result.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Возвращает URI для скачивания из облака
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async Task<GetUploadUriResponse> GetDownloadUri(string fileName)
        {
            var BasePath = _configuration["YandexDisk:BasePath"];
            var uri = $"resources/download?path={BasePath}{fileName}";
            var result = await _httpClient.GetAsync(HttpUtility.HtmlEncode(uri));
            result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetUploadUriResponse>(await result.Content.ReadAsStringAsync());
        }
    }
}