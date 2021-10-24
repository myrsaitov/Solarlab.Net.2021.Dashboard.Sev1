using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using Sev1.Advertisements.Application.Contracts.GetPaged;

namespace Sev1.Advertisements.Application.Interfaces.Category
{
    public interface ICategoryService
    {
        /// <summary>
        /// Создает новую категорию
        /// </summary>
        /// <param name="accessToken">JWT-токен</param>
        /// <param name="model">Модель DTO категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> Create(
            string accessToken,
            CategoryCreateDto model,
            CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующую категорию
        /// </summary>
        /// <param name="accessToken">JWT-токен</param>
        /// <param name="model">Модель DTO категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> Update(
            string accessToken,
            CategoryUpdateDto request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет категорию по Id
        /// </summary>
        /// <param name="accessToken">JWT-токен</param>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Delete(
            string accessToken,
            int id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Восстанавливает категорию по Id
        /// </summary>
        /// <param name="accessToken">JWT-токен</param>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Restore(
            string accessToken,
            int id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает категорию по Id
        /// </summary>
        /// <param name="id">Id категории</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<CategoryDto> GetById(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает категории с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetPagedResponse<CategoryDto>> GetPaged(
            GetPagedRequest request, 
            CancellationToken cancellationToken);
    }
}