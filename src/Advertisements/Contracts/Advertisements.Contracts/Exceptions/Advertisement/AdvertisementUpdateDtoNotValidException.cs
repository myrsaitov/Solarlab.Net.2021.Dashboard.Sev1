using System;

namespace Sev1.Advertisements.Contracts.Exceptions.Advertisement
{
    public class AdvertisementUpdateDtoNotValidException : ApplicationException
    {
        public AdvertisementUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}