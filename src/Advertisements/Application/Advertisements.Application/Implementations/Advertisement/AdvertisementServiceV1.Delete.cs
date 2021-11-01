using System;
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
        /// Удаляет объявление
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="id">Id объявления</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task Delete(
            string accessToken,
            int id,
            CancellationToken cancellationToken)
        {
            // Проверяем, авторизирован ли пользователь, получаем его Id и Role
            var autorizedStatus = await _userApiClient.ValidateToken(
                accessToken,
                cancellationToken);
            if (autorizedStatus is null)
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

            // Достаем объявление из базы
            var advertisement = await _advertisementRepository.FindByIdWithTagsInclude(
                id,
                cancellationToken);

            // Если объявления с таким Id нет, то выход
            if (advertisement == null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            // Пользователь может удалять объявление:
            //  - если он администратор;
            //  - если он модератор;
            //  - если он создал это объявление.
            var isAdmin = (autorizedStatus.Role == "admin");
            var isModerator = (autorizedStatus.Role == "moderator");
            var isOwnerId = (advertisement.OwnerId == autorizedStatus.UserId);
            if(!(isAdmin||isModerator||isOwnerId))
            {
                throw new NoRightsException("Не хватает прав удалить объявление!");
            }

            // Объявленние не удаляется, а лишь помечается удаленным
            advertisement.IsDeleted = true;

            // Обновляется дата редактирования
            advertisement.UpdatedAt = DateTime.UtcNow;

            // TODO Сделать нормальный подсчет количества Tags
            // Убираем из количества объявлений по данному тагу единицу
            if (advertisement.Tags is not null)
            {
                foreach (var tag in advertisement.Tags)
                {
                    if (tag.Count > 0)
                    {
                        tag.Count -= 1;
                        await _tagRepository.Save(
                            tag,
                            cancellationToken);
                    }
                }
            }

            // Сохраняем изменения в базу
            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}