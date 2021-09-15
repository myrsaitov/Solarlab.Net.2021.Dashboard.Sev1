﻿using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Services.Category.Contracts.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Категория с таким ID[{0}] не была найдена.";
        public CategoryNotFoundException(int adId) : base(string.Format(MessageTemplate, adId))
        {
        }
    }
}