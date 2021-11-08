using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Sev1.UserFiles.Contracts.Contracts.YandexDisk;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Sev1.UserFiles.Contracts.ApiClients.YandexDisk
{
    public class YandexDiskApiClient : IYandexDiskApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "disk:/";

        public YandexDiskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Upload(IFormFile data)
        {
            var uploadUrl = await GetUploadUrl(data.FileName);
            var result = await _httpClient.PutAsync(new Uri(uploadUrl.Href), new StreamContent(data.OpenReadStream()));
            result.EnsureSuccessStatusCode();

            var downloadUrl = await GetDownloadUrl(data.FileName);
            return downloadUrl.Href;
        }

        private async Task<GetUploadUrlResponse> GetUploadUrl(string fileName)
        {
            var url = $"resources/upload?path={BasePath}{fileName}";
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("OAuth", "AQAEA7qjaEQ0AADLW2_1Ii0Xq0Xiv7Sf9fqXPw0");
            var result = await _httpClient.GetAsync(HttpUtility.HtmlEncode(url));
            result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetUploadUrlResponse>(await result.Content.ReadAsStringAsync());
        }

        private async Task<GetUploadUrlResponse> GetDownloadUrl(string fileName)
        {
            var url = $"resources/download?path={BasePath}{fileName}";
            var result = await _httpClient.GetAsync(HttpUtility.HtmlEncode(url));
            result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetUploadUrlResponse>(await result.Content.ReadAsStringAsync());
        }
    }
}