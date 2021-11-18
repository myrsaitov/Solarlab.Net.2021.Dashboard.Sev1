using System.Threading.Tasks;

namespace Sev1.Avdertisements.Contracts.ApiClients.RegionValidate
{
    public interface IRegionValidateApiClient
    {
        /// <summary>
        /// Проверяет, существует ли объявление 
        /// с таким идентификатором,
        /// а также, является ли текущий пользователь
        /// владельцем этого объявления
        /// </summary>
        /// <param name="regionId">Идентификатор объявления, которое проверяем</param>
        /// <returns></returns>
        Task<bool> RegionValidate(
            int? regionId);
    }
}