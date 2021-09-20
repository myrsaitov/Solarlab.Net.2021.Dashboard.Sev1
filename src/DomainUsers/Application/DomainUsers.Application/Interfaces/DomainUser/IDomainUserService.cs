using System.Threading;
using System.Threading.Tasks;
using Sev1.DomainUsers.Application.Contracts.DomainUser;
using Sev1.DomainUsers.Application.Contracts.GetPaged;

namespace Sev1.DomainUsers.Application.Interfaces.DomainUser
{
    public interface IDomainUserService
    {
        /// <summary>
        /// Создает новую категорию
        /// </summary>
        /// <param name="model">Модель DTO категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> Create(
            DomainUserCreateDto model, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующую категорию
        /// </summary>
        /// <param name="model">Модель DTO категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> Update(
            DomainUserUpdateDto request, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет категорию по Id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Delete(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Восстанавливает категорию по Id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Restore(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает категорию по Id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<DomainUserDto> GetById(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает категории с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetPagedResponse<DomainUserDto>> GetPaged(
            GetPagedRequest request, 
            CancellationToken cancellationToken);
    }
}