using Sev1.UserFiles.Domain.Exceptions;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.IO;
using UserFiles.Contracts.ApiClients.HttpGet;

namespace Sev1.UserFiles.Contracts.ApiClients.Advertisement
{
    public sealed partial class AdvertisementApiClient : IAdvertisementApiClient
    {
        public AdvertisementApiClient()
        {
        }

        public async Task<bool> ValidateAdvertisement(
            int advertisementId,
            string ownerId)
        {
            // Создатся адрес GET-запроса объявления
            string url = "https://localhost:44378/api/v1/advertisements/" + advertisementId.ToString();

            var httpGet = new HttpGet();
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