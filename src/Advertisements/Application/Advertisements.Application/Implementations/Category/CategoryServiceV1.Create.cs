﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Category;
using System.Collections.Generic;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Validators.Advertisement;
using Sev1.Advertisements.Application.Exceptions.Advertisement;
using System.Linq;
using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Implementations.Category
{
    public sealed partial class CategoryServiceV1 : ICategoryService
    {
        /// <summary>
        /// Создать категорию (только админ или модератор)
        /// </summary>
        /// <param name="accessToken">JWT Token, который пришел с запросом</param>
        /// <param name="model">DTO</param>
        /// <param name="cancellationToken">Маркёр отмены</param>
        /// <returns></returns>
        public async Task<int> Create(
            string accessToken,
            CategoryCreateDto model, 
            CancellationToken cancellationToken)
        {
            // Проверяем, авторизирован ли пользователь, получаем его Id и Role
            var autorizedStatus = await _userApiClient.ValidateToken(
                accessToken);
            if (autorizedStatus is null)
            {
                throw new NoRightsException("Ошибка авторизации!");
            }

            // Fluent Validation
            var validator = new CategoryCreateDtoValidator();
            var result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new CategoryCreateDtoNotValidException(result.Errors.Select(x => x.ErrorMessage).ToString());
            }

            // Пользователь может создать категорию:
            //  - если он администратор;
            //  - если он модератор;
            /*var isAdmin = (autorizedStatus.Role == "admin");
            var isModerator = (autorizedStatus.Role == "moderator");
            if (!(isAdmin || isModerator))
            {
                throw new NoRightsException("Только модератор или админ!");
            }*/

            // Создаем категорию
            var category = _mapper.Map<Domain.Category>(model);
            category.IsDeleted = false;
            category.CreatedAt = DateTime.UtcNow;
            await _categoryRepository.Save(category, cancellationToken);

            // Редактируем родительскую категорию, если есть
            var parentCategoryIdNulable = model.ParentCategoryId;
            if (parentCategoryIdNulable != null)
            {
                int parentCategoryId = (int)parentCategoryIdNulable;
                var parentCategory = await _categoryRepository.FindById(parentCategoryId, cancellationToken);
                if (parentCategory != null)
                {
                    if (parentCategory.ChildCategories != null)
                    {
                        parentCategory.ChildCategories.Add(category);
                    }
                    else
                    {
                        parentCategory.ChildCategories = new List<Domain.Category>()
                        {
                            category
                        };
                    }
                    await _categoryRepository.Save(parentCategory, cancellationToken);
                    
                    category.ParentCategory = parentCategory;
                }
                await _categoryRepository.Save(category, cancellationToken);
            }

            return category.Id;
        }
    }
}