using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Contracts.GetPaged;

namespace Sev1.Advertisements.Application.Interfaces.Advertisement
{
    public interface IAdvertisementService
    {
        /// <summary>
        /// Создает новое объявление
        /// </summary>
        /// <param name="model">Модель DTO объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Create(
            AdvertisementCreateDto model, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующее обявление
        /// </summary>
        /// <param name="model">Модель DTO объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> Update(
            AdvertisementUpdateDto model, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет объявление по Id
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Delete(
            int id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Восстанавливает объявление по Id
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Restore(
            int id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявление по Id
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<AdvertisementDto> GetById(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявления с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetPagedAdvertisementResponse> GetPaged(
            GetPagedAdvertisementRequest request, 
            CancellationToken cancellationToken);
    }
}