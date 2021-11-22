using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.AppServices.Contracts.Advertisement.Requests;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Requests;
using Sev1.Advertisements.Contracts.Contracts.Advertisement.Responses;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Requests;
using Sev1.Advertisements.Contracts.Contracts.GetPaged.Responses;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces
{
    public interface IAdvertisementService
    {
        /// <summary>
        /// Создает новое объявление
        /// </summary>
        /// <param name="request">Модель DTO объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<AdvertisementCreatedResponse> Create(
            AdvertisementCreateRequest request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующее обявление
        /// </summary>
        /// <param name="request">Модель DTO объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<AdvertisementUpdatedResponse> Update(
            AdvertisementUpdateRequest request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет статус существующего обявления
        /// </summary>
        /// <param name="request">Модель DTO объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<AdvertisementUpdatedResponse> UpdateStatus(
            AdvertisementUpdateStatusRequest request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет объявление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Delete(
            int? id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Восстанавливает объявление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Restore(
            int? id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявление по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<AdvertisementGetResponse> GetById(
            int? id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявления с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<AdvertisementGetPagedResponse> GetPaged(
            AdvertisementGetPagedRequest request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Добавить таги к объявлению
        /// </summary>
        /// <param name="advertisement">Объект объявления</param>
        /// <param name="TagBodies">Массив тагов</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task AddTags(
            Domain.Advertisement advertisement,
            string[] TagBodies,
            CancellationToken cancellationToken);
    }
}