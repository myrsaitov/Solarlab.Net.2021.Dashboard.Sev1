using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace sev1.Advertisements.Application.Advertisement.Interfaces
{
    public interface IAdvertisementService
    {
        Task<Create.Response> Create(
            Create.Request request, 
            CancellationToken cancellationToken);
        Task<Update.Response> Update(
            Update.Request request, 
            CancellationToken cancellationToken);
        Task Delete(
            Delete.Request request, 
            CancellationToken cancellationToken);
        Task Restore(
            Restore.Request request, 
            CancellationToken cancellationToken);
        Task<GetById.Response> GetById(
            GetById.Request request, 
            CancellationToken cancellationToken);
        Task<Paged.Response<GetPaged.Response>> GetPaged(
            Paged.Request request, 
            CancellationToken cancellationToken);
        Task<Paged.Response<GetPaged.Response>> GetPaged(
            Expression<Func<Domain.Content, bool>> predicate,
            Paged.Request request,
            CancellationToken cancellationToken);
    }
}