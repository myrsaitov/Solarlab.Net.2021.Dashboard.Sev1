using System;

namespace Sev1.UserFiles.Application.Exceptions.Advertisement
{
    public class AdvertisementCreateDtoNotValidException : ApplicationException
    {
        public AdvertisementCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}