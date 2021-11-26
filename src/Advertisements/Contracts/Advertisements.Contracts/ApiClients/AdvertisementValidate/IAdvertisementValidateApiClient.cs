using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using System.Threading.Tasks;

namespace Sev1.Avdertisements.Contracts.ApiClients.AdvertisementValidate
{
    public interface IAdvertisementValidateApiClient
    {
        /// <summary>
        /// Проверяет, существует ли объявление 
        /// с таким идентификатором,
        /// а также, является ли текущий пользователь
        /// владельцем этого объявления
        /// </summary>
        /// <param name="advertisementId">Идентификатор объявления, которое проверяем</param>
        /// <param name="ownerId">Идентификатор владельца объявления</param>
        /// <returns></returns>
        Task<bool> AdvertisementValidate(
            int? advertisementId,
            string ownerId);

        /// <summary>
        /// Получить объявление по Id 
        /// </summary>
        /// <param name="advertisementId">Идентификатор объявления</param>
        /// <returns></returns>
        Task<AdvertisementGetResponse> GetAdvertisementById(int advertisementId);
    }
}