using System;

namespace Sev1.Advertisements.Application.Exceptions.Advertisement
{
    public class AdvertisementCreateDtoNotValidException : ApplicationException
    {
        public AdvertisementCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}