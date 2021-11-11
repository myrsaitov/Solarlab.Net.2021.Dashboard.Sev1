using System;

namespace Sev1.Advertisements.Contracts.Exceptions.Advertisement
{
    public class AdvertisementIdNotValidException : ApplicationException
    {
        public AdvertisementIdNotValidException(string message) : base(message)
        {
        }
    }
}