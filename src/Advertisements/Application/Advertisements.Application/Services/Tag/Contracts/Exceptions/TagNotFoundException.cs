﻿using Sev1.Advertisements.Domain.Exceptions;

namespace Sev1.Advertisements.Application.Services.Tag.Contracts.Exceptions
{
    public sealed class TagNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Tag с таким ID[{0}] не был найден.";
        public TagNotFoundException(int adId) : base(string.Format(MessageTemplate, adId))
        {
        }
    }
}