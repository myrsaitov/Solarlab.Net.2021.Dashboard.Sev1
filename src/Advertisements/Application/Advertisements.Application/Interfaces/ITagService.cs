using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts;
using Sev1.Advertisements.Application.Contracts.Tag;

namespace Sev1.Advertisements.Application.Interfaces
{
    public interface ITagService
    {
        Task<Paged.Response<TagPagedDto>> GetPaged(
            Paged.Request request,
            CancellationToken cancellationToken);
    }
}