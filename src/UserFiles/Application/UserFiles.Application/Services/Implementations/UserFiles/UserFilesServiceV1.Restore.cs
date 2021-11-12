using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Exceptions.UserFile;
using Sev1.UserFiles.Application.Services.Interfaces.UserFile;
using Sev1.UserFiles.Application.Services.Validators.UserFile;
using Sev1.UserFiles.Application.Exceptions;
using Sev1.UserFiles.Application.Exceptions.Domain;

namespace Sev1.UserFiles.Application.Services.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Восстановить объявление
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Restore(
            int id,
            CancellationToken cancellationToken)
        {
            // Fluent Validation
            var validator = new UserFilesIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new UserFileIdNotValidException(
                    result
                    .Errors
                    .Select(x => x.ErrorMessage)
                    .ToString());
            }

            var userFiles = await _userFileRepository.FindById(
                id,
                cancellationToken);

            if (userFiles == null)
            {
                throw new UserFileNotFoundException(id);
            }

            // Пользователь может восстановить объявление:
            //  - если он создал это объявление;
            //  - модератор и администратор не могут это сделать;
            var isOwnerId = (userFiles.OwnerId == _userProvider.GetUserId());
            if (!isOwnerId)
            {
                throw new NoRightsException("Вы не создали это объявление!");
            }

            userFiles.IsDeleted = false;
            userFiles.UpdatedAt = DateTime.UtcNow;
            await _userFileRepository.Save(
                userFiles, 
                cancellationToken);
        }
    }
}