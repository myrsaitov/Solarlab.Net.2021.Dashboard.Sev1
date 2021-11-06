using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.Application.Contracts.UserFile;
using Sev1.UserFiles.Application.Exceptions.UserFile;
using Sev1.UserFiles.Application.Interfaces.UserFile;
using Sev1.UserFiles.Application.Validators.UserFile;

namespace Sev1.UserFiles.Application.Implementations.UserFile
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Получить объявление по Id
        /// </summary>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserFileDto> GetById(
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

            var userFiles = await _userFileRepository.FindById(
                id,
                cancellationToken);

            if (userFiles == null)
            {
                throw new UserFileNotFoundException(id);
            }

            var response = _mapper.Map<UserFileDto>(userFiles);

            return response;
        }
    }
}