using Sev1.Advertisements.Domain.Base.Exceptions;

namespace Sev1.Advertisements.AppServices.Services.Region.Exceptions
{
    /// <summary>
    /// Исключение, если регион с таким идентификатором не был найден
    /// </summary>
    public sealed class RegionNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Регион с таким ID[{0}] не был найден.";
        public RegionNotFoundException(int? Id) : base(string.Format(MessageTemplate, Id))
        {
        }
    }
}