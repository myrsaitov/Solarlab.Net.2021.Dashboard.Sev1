using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using System;
using Sev1.Advertisements.Contracts.Contracts.Region.Responses;

namespace Sev1.Avdertisements.Contracts.ApiClients.RegionValidate
{
    public sealed partial class RegionValidateApiClient : IRegionValidateApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;

        public RegionValidateApiClient(
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
        /// <param name="regionId">Идентификатор объявления, которое проверяем</param>
        /// <returns></returns>
        public async Task<bool> RegionValidate(
            int? regionId)
        {
            // Считыватем URI запроса из конфига "appsettings.json"
            string uri = _configuration["RegionValidateApiClientUri"] + regionId.ToString();
            if(string.IsNullOrWhiteSpace(uri))
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
            var regionDto = JsonConvert
                .DeserializeObject<RegionGetResponse>(responseJson);

            // Логика проверки региона на соответствие
            if (regionDto.Id == regionId)
            {
                // Если Id региона совпадает, то проверка пройдена
                return true;
            }
            else
            {
                // Иначе - регион не существует
                throw new Exception("Регион не существует!");
            }
        }
    }
}