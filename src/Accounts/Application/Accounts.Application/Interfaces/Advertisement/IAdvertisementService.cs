using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Accounts.Application.Contracts.Account;
using Sev1.Accounts.Application.Contracts;
using Sev1.Accounts.Application.Contracts.GetPaged;

namespace Sev1.Accounts.Application.Interfaces.Account
{
    public interface IAccountService
    {
        /// <summary>
        /// Создает новое объявление
        /// </summary>
        /// <param name="model">Модель DTO объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task Create(
            AccountCreateDto model, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующее обявление
        /// </summary>
        /// <param name="model">Модель DTO объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<int> Update(
            AccountUpdateDto model, 
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
        Task<AccountDto> GetById(
            int id, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает объявления с пагинацией
        /// </summary>
        /// <param name="request">Параметры пагинации</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        Task<GetPagedAccountResponse> GetPaged(
            GetPagedAccountRequest request, 
            CancellationToken cancellationToken);
    }
}