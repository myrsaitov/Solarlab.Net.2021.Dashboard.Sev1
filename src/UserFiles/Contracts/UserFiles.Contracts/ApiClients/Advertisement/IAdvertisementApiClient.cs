using System.Threading.Tasks;

namespace Sev1.UserFiles.Contracts.ApiClients.Advertisement
{
    public interface IAdvertisementApiClient
    {
        /// <summary>
        /// Проверяет, существует ли объявление с таким Id,
        /// а также, является ли текущий пользователь владельцем 
        /// этого объявления
        /// </summary>
        /// <param name="advertisementId">Id объявления, которое проверяем</param>
        /// <param name="ownerId">Id владельца объявления</param>
        /// <returns></returns>
        Task<bool> ValidateAdvertisement(
            int advertisementId,
            string ownerId);
    }
}