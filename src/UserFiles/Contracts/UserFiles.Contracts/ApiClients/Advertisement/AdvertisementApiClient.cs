using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sev1.UserFiles.Contracts.Exceptions;
using UserFiles.Contracts.ApiClients.HttpGet;

namespace Sev1.UserFiles.Contracts.ApiClients.Advertisement
{
    public sealed partial class AdvertisementApiClient : IAdvertisementApiClient
    {
        private readonly IConfiguration _configuration;
        public AdvertisementApiClient(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ValidateAdvertisement(
            int advertisementId,
            string ownerId)
        {
            // Считыватем URL запроса из конфига "appsettings.json"
            string url = _configuration["Advertisements"] + advertisementId.ToString();

            // Осуществление GET-запроса
            var httpGet = new HttpGet(); // TODO здесь DI или new?
            var result = await httpGet.HttpGetAsync(url);
            
            // Конвертируем JSON в DTO
            var advertisementDto = JsonConvert
                .DeserializeObject<AdvertisementDto>(result);

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