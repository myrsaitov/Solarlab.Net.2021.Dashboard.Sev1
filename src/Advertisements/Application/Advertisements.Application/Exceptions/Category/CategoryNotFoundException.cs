﻿using Sev1.Advertisements.AppServices.Exceptions.Domain;

namespace Sev1.Advertisements.AppServices.Exceptions.Category
{
    /// <summary>
    /// Исключение, если категория с таким идентификатором не была найдена
    /// </summary>
    public sealed class CategoryNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Категория с таким ID[{0}] не была найдена.";
        public CategoryNotFoundException(int? Id) : base(string.Format(MessageTemplate, Id))
        {
        }
    }
}