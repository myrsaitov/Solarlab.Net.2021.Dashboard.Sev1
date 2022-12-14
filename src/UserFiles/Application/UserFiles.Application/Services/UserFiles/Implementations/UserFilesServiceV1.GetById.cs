using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.UserFiles.AppServices.Services.Advertisement.UserFile;
using Sev1.UserFiles.AppServices.Services.UserFile.Interfaces;
using Sev1.UserFiles.AppServices.Services.UserFile.Validators;
using Sev1.UserFiles.Contracts.Contracts.UserFile.Responses;

namespace Sev1.UserFiles.AppServices.Services.UserFile.Implementations
{
    public sealed partial class UserFileServiceV1 : IUserFileService
    {
        /// <summary>
        /// Получить объявление по Id
        /// </summary>
        /// <param name="id">Идентификатор объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<UserFileGetResponse> GetById(
            int? id,
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

            var response = _mapper.Map<UserFileGetResponse>(userFiles);

            return response;
        }
    }
}