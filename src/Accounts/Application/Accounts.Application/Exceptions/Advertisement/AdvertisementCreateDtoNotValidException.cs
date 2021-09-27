using System;

namespace Sev1.Accounts.Application.Exceptions.Advertisement
{
    public class AdvertisementCreateDtoNotValidException : ApplicationException
    {
        public AdvertisementCreateDtoNotValidException(string message) : base(message)
        {
        }
    }
}