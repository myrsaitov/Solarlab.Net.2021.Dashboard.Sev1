using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Requests;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Responses;
using Newtonsoft.Json;
using System.Text;
using Sev1.Accounts.Contracts.UserProvider;

namespace Sev1.UserFiles.Contracts.ApiClients.UserFilesUpload
{
    public sealed partial class UserFilesUploadApiClient : IUserFilesUploadApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IUserProvider _userProvider;

        public UserFilesUploadApiClient(
            IConfiguration configuration,
            IHttpClientFactory clientFactory,
            IUserProvider userProvider)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
            _userProvider = userProvider;
        }

        /// <summary>
        /// Проверяет, существует ли объявление 
        /// с таким идентификатором,
        /// а также, является ли текущий пользователь
        /// владельцем этого объявления
        /// </summary>
        /// <param name="advertisementId">Идентификатор объявления, которое проверяем</param>
        /// <param name="ownerId">Идентификатор владельца объявления</param>
        /// <returns></returns>
        public async Task<UserFileBase64UploadResponse> UploadBase64(
            List<UserFileBase64UploadRequest> Files)
        {
            // Считыватем URI запроса из конфига "appsettings.json"
            string uri = _configuration["UserFilesUploadApiClientUri"];
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new Exception("API-клиент: адрес не задан");
            }

            // Проверка авторизации
            var authorizationHeader = _userProvider.GetAuthorizationHeader();
            if (authorizationHeader is null)
            {
                throw new Exception("Ошибка авторизации!");
            }

            // Данные к пост-запросу
            string jsonString = JsonConvert.SerializeObject(Files);
            var payload = new StringContent(
                jsonString,
                Encoding.UTF8,
                "application/json");

            // Создание клиента
            var client = _clientFactory.CreateClient();

            // Добавляем хидер авторизации
            client.DefaultRequestHeaders.Add(
                "Authorization",
                authorizationHeader);

            // Выполнение POST-запроса
            HttpResponseMessage response = await client.PostAsync(
                uri,
                payload);

            // Преобразование в json
            string responseJson = await response.Content.ReadAsStringAsync();

            // Конвертируем JSON в DTO
            var responseDto = JsonConvert
                .DeserializeObject<UserFileBase64UploadResponse>(responseJson);

            return responseDto;
        }
    }
}