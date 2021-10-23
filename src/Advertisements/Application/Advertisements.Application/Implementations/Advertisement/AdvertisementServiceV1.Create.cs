using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Contracts.Tag;
using Sev1.Advertisements.Application.Validators.Advertisement;
using System.Linq;
using Sev1.Advertisements.Application.Exceptions.Category;
using System.Net;
using System.Text;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Implementations.Advertisement
{
    public sealed partial class AdvertisementServiceV1 : IAdvertisementService
    {
        public async Task Create(
            AdvertisementCreateDto model,
            CancellationToken cancellationToken)
        {
            // WebClient
            /*string param = "";
            string url = "https://localhost:44377/api/v1/accounts/user";
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                client.Headers.Add("Authorization", accessToken);
                try
                {
                    string userId = Encoding.ASCII.GetString(client.UploadData(url, "POST", Encoding.UTF8.GetBytes(param)));
                    model.OwnerId = userId;
                }
                catch (WebException ex)
                {
                    throw new NoRightsException("Ошибка авторизации"); // TODO
                }
            }*/


            // Fluent Validation
            var validator = new AdvertisementCreateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new AdvertisementCreateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            var category = await _categoryRepository.FindById(
                model.CategoryId,
                cancellationToken);

            if (category is null)
            {
                throw new CategoryNotFoundException(model.CategoryId);
            }

            var advertisement = _mapper.Map<Domain.Advertisement>(model);
            advertisement.IsDeleted = false;
            advertisement.CreatedAt = DateTime.UtcNow;
            advertisement.Category = category;

            if (model.TagBodies is not null)
            {
                advertisement.Tags = new List<Domain.Tag>();
                foreach (string body in model.TagBodies)
                {
                    if (body.Length > 0)
                    {
                        var tag = await _tagRepository.FindWhere(
                            a => a.Body == body,
                            cancellationToken);

                        if (tag == null)
                        {
                            var tagRequest = new TagCreateDto()
                            {
                                Body = body
                            };

                            tag = _mapper.Map<Domain.Tag>(tagRequest);
                            tag.CreatedAt = DateTime.UtcNow;
                            tag.Count = 1;

                            await _tagRepository.Save(
                                tag, 
                                cancellationToken);
                        }
                        else
                        {
                            // TODO Переделать с поиском в базе, учесть удаленные объявления
                            tag.Count += 1;
                            await _tagRepository.Save(tag, cancellationToken);
                        }

                        advertisement.Tags.Add(tag);
                    }
                }
            }

            await _advertisementRepository.Save(
                advertisement, 
                cancellationToken);
        }
    }
}