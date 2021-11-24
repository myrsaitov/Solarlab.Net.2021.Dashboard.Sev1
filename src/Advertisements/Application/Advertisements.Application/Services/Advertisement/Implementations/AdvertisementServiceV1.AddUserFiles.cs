using System.Threading;
using System.Threading.Tasks;
using System;
using Sev1.Advertisements.AppServices.Services.Advertisement.Interfaces;
using System.Collections.Generic;
using Sev1.Advertisements.Contracts.Contracts.Tag.Requests;

namespace Sev1.Advertisements.AppServices.Services.Advertisement.Implementations
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Добавить таги к объявлению
        /// </summary>
        /// <param name="advertisement">Объект объявления</param>
        /// <param name="TagBodies">Массив тагов</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task AddUserFiles(
            Domain.Advertisement advertisement,
            List<int?> FileId,
            CancellationToken cancellationToken)
        {
            // Добавляем таги
            if (FileId is not null)
            {
                advertisement.UserFiles = new List<Domain.UserFile>();
                foreach (var id in FileId)
                {
                    if (id is not null)
                    {
                        var fileId = await _userFileRepository.FindWhere(
                            a => a.FileId == id,
                            cancellationToken);

                        if (fileId == null)
                        {
                            var userFileRequest = new UserFileCreateRequest()
                            {
                                FileId = id
                            };

                            fileId = _mapper.Map<Domain.UserFile>(userFileRequest);
                            fileId.CreatedAt = DateTime.UtcNow;

                            await _userFileRepository.Save(
                                fileId,
                                cancellationToken);
                        }
                        else
                        {
                            await _userFileRepository.Save(fileId, cancellationToken);
                        }

                        advertisement.UserFiles.Add(fileId);
                    }
                }
            }
        }
    }
}