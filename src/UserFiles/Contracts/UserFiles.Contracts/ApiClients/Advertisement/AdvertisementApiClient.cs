using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sev1.UserFiles.Contracts.Contracts.Advertisement;
using Sev1.UserFiles.Contracts.Exceptions;

namespace Sev1.UserFiles.Contracts.ApiClients.Advertisement
{
    public sealed partial class AdvertisementApiClient : IAdvertisementApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;

        public AdvertisementApiClient(
            IConfiguration configuration,
            IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        public async Task<bool> ValidateAdvertisement(
            int advertisementId,
            string ownerId)
        {
            // Считыватем URI запроса из конфига "appsettings.json"
            string uri = _configuration["Advertisements"] + advertisementId.ToString();

            // Создание клиента
            var client = _clientFactory.CreateClient();

            // Выполнение GET-запроса
            HttpResponseMessage response = await client.GetAsync(uri);

            // Преобразование в json
            string responseJson = await response.Content.ReadAsStringAsync();

            // Конвертируем JSON в DTO
            var advertisementDto = JsonConvert
                .DeserializeObject<AdvertisementDto>(responseJson);

            // Логика проверки объявления на соответствие
            if (advertisementDto.OwnerId == ownerId)
            {
                // Если Id пользователей совпадает, то проверка пройдена
                return true;
            }
            else
            {
                // Иначе - не достаточно прав!
                throw new NoRightsException("Не достаточно прав!");
            }
        }
    }
}