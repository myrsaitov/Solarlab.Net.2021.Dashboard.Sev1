﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Validators.Advertisement;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        /// <summary>
        /// Восстановить объявление
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Restore(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Получаем Id текущего пользователя
            var currentUserId = await _userRepository.GetCurrentUserId(
                accessToken, 
                cancellationToken);
            if(currentUserId == null)
            {
                throw new NoRightsException("Ошибка авторизации!");
            }

            // Fluent Validation
            var validator = new AdvertisementIdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new AdvertisementIdNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var advertisement = await _advertisementRepository.FindByIdWithUserInclude(
                id,
                cancellationToken);

            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            // Пользователь может восстановить объявление:
            //  - если он администратор;
            //  - если он модератор;
            //  - если он создал это объявление.
            var isAdmin = await _userRepository.IsAdmin(
                accessToken,
                cancellationToken);
            var isModerator = await _userRepository.IsModerator(
                accessToken,
                cancellationToken);
            var isOwner = (advertisement.OwnerId == currentUserId);
            if (!(isAdmin || isModerator || isOwner))
            {
                throw new NoRightsException("Не хватает прав восстановить объявление!");
            }

            advertisement.IsDeleted = false;
            advertisement.UpdatedAt = DateTime.UtcNow;
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}