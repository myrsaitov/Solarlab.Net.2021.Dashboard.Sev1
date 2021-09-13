using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Services.Contracts;
using Sev1.Advertisements.Application.Services.Tag.Contracts;

namespace Sev1.Advertisements.Application.Services.Tag.Interfaces
{
    public interface ITagService
    {
        Task<Paged.Response<GetById.Response>> GetPaged(
            Paged.Request request,
            CancellationToken cancellationToken);
    }
}