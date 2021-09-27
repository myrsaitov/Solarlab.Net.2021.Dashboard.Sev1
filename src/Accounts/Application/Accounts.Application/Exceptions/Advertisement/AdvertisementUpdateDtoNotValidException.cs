using System;

namespace Sev1.Accounts.Application.Exceptions.Advertisement
{
    public class AdvertisementUpdateDtoNotValidException : ApplicationException
    {
        public AdvertisementUpdateDtoNotValidException(string message) : base(message)
        {
        }
    }
}