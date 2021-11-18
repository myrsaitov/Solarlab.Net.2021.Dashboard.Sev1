using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sev1.Accounts.Contracts.Contracts.User.Responses;

namespace Sev1.Accounts.Contracts.ApiClients.User
{
    /// <summary>
    /// API-client проверяет, авторизирован ли пользователь, возвращает его id и role
    /// </summary>
    public sealed partial class UserValidateApiClient : IUserValidateApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;

        public UserValidateApiClient(
            IConfiguration configuration,
            IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// API-client проверяет, авторизирован ли пользователь, возвращает его id и role
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <returns></returns>
        public async Task<ValidateTokenResponse> UserValidate(
            string accessToken)
        {
            // Проверка наличия токена
            if(accessToken is null)
            {
                throw new Exception("Ошибка авторизации!");
            }

            // Считыватем URI запроса из конфига "appsettings.json"
            string uri = _configuration["UserValidateApiClientUri"];
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new Exception("API-клиент: адрес не задан");
            }

            // Данные к пост-запросу
            string jsonString = "";
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // Создание клиента
            var client = _clientFactory.CreateClient();

            // Добавляем хидер авторизации
            client.DefaultRequestHeaders.Add("Authorization", accessToken);

            // Выполнение POST-запроса
            HttpResponseMessage response = await client.PostAsync(uri, payload);

            // Преобразование в json
            string responseJson = await response.Content.ReadAsStringAsync();

            // Преобразуем json в DTO
            ValidateTokenResponse res = JsonConvert.DeserializeObject<ValidateTokenResponse>(responseJson);

            // Если null, то ошибка авторизация
            if(res is null)
            {
                throw new Exception("Ошибка авторизации!");
            }

            // Возвращаем DTO
            return res;
        }
    }
}