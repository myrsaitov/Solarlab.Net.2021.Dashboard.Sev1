using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Exceptions.UserFile;
using Sev1.UserFiles.Application.Interfaces.UserFile;
using Sev1.UserFiles.Application.Validators.UserFile;
using Sev1.UserFiles.Contracts.Exceptions;

namespace Sev1.UserFiles.Application.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Удаляет объявление
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Delete(
            int id,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new UserFilesIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new UserFileIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Достаем карточку файла из базы
            var userFiles = await _userFileRepository.FindById(
                id,
                cancellationToken);

            // Если объявления с таким Id нет, то выход
            if (userFiles == null)
            {
                throw new UserFileNotFoundException(id);
            }

            // Пользователь может удалять файл:
            //  - если он администратор;
            //  - если он модератор;
            //  - если он создал это объявление.
            var isAdministrator = _userProvider.IsInRole("Administrator");
            var isModerator = _userProvider.IsInRole("Moderator");
            var isOwnerId = (userFiles.OwnerId == _userProvider.GetUserId());
            if(!(isAdministrator||isModerator||isOwnerId))
            {
                throw new NoRightsException("Не хватает прав удалить объявление!");
            }

            // Объявленние не удаляется, а лишь помечается удаленным
            userFiles.IsDeleted = true;

            // Обновляется дата редактирования
            userFiles.UpdatedAt = DateTime.UtcNow;

            // Сохраняем изменения в базу
            await _userFileRepository.Save(
                userFiles, 
                cancellationToken);
        }
    }
}