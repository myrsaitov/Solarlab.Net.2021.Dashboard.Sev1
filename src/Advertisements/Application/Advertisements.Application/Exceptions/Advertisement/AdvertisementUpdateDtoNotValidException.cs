using System;

namespace Sev1.Advertisements.Application.Exceptions.Advertisement
{
    public class AdvertisementUpdateDtoNotValidException : ApplicationException
    {
        public AdvertisementUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}