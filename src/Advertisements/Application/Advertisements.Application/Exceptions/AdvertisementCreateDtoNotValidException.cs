using System;

namespace Sev1.Advertisements.Application.Exceptions
{
    public class AdvertisementCreateDtoNotValidException : ApplicationException
    {
        public AdvertisementCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}