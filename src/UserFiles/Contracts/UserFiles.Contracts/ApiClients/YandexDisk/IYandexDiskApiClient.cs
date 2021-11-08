using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sev1.UserFiles.Contracts.ApiClients.YandexDisk
{
    public interface IYandexDiskApiClient
    {
        Task<string> Upload(IFormFile data);
    }
}