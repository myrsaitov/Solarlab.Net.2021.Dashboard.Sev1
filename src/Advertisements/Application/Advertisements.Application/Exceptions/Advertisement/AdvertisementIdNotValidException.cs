﻿using System;

namespace Sev1.Advertisements.Application.Exceptions.Advertisement
{
    public class AdvertisementIdNotValidException : ApplicationException
    {
        public AdvertisementIdNotValidException(string message) : base(message)
        {
        }
    }
}