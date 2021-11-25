using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using System;
using Sev1.Accounts.Domain.Base.Exceptions;

namespace Sev1.Avdertisements.Contracts.ApiClients.AdvertisementValidate
{
    public sealed partial class AdvertisementValidateApiClient : IAdvertisementValidateApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;

        public AdvertisementValidateApiClient(
            IConfiguration configuration,
            IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
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
        public async Task<bool> AdvertisementValidate(
            int? advertisementId,
            string ownerId)
        {
            // Считыватем URI запроса из конфига "appsettings.json"
#if DEBUG
            string uri = _configuration["AdvertisementValidateApiClientUri"] + advertisementId.ToString();
#else
            string uri = _configuration["AdvertisementValidateApiClientUri_DockerNoSSL"] + advertisementId.ToString();
#endif
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new Exception("API-клиент: адрес не задан");
            }

            // Создание клиента
            var client = _clientFactory.CreateClient();

            // Выполнение GET-запроса
            HttpResponseMessage response = await client.GetAsync(uri);

            // Преобразование в json
            string responseJson = await response.Content.ReadAsStringAsync();

            // Конвертируем JSON в DTO
            var advertisementDto = JsonConvert
                .DeserializeObject<AdvertisementGetResponse>(responseJson);

            // Логика проверки объявления на соответствие
            if (advertisementDto.OwnerId == ownerId)
            {
                // Если Id пользователей совпадает, то проверка пройдена
                return true;
            }
            else
            {
                // Иначе - не достаточно прав!
                throw new Exception("Не достаточно прав!");
            }
        }

        /// <summary>
        /// Получить объявление по Id 
        /// </summary>
        /// <param name="advertisementId">Идентификатор объявления</param>
        /// <returns></returns>
        public async Task<AdvertisementGetResponse> GetAdvertisementById(int advertisementId)
        {
            // Считыватем URI запроса из конфига "appsettings.json"
#if DEBUG
            string uri = _configuration["AdvertisementApiClientUriGet"] + advertisementId.ToString();
#else
            string uri = _configuration["AdvertisementApiClientUriGet_DockerNoSSL"] + advertisementId.ToString();
#endif
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new Exception("API-клиент: адрес не задан");
            }

            // Создание клиента
            var client = _clientFactory.CreateClient();

            // Выполнение GET-запроса
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException($"Объявление {advertisementId} не было найдено!");
            }
            // Преобразование в json
            string responseJson = await response.Content.ReadAsStringAsync();

            // Конвертируем JSON в DTO
            var advertisementDto = JsonConvert
                .DeserializeObject<AdvertisementGetResponse>(responseJson);

            return advertisementDto;
        }
    }
}