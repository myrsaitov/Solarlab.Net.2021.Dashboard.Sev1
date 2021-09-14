using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Application.Contracts.Advertisement;
using Sev1.Advertisements.Application.Contracts;

namespace Sev1.Advertisements.Application.Interfaces
{
    public interface IAdvertisementService
    {
        Task Create(
            AdvertisementCreateDto request, 
            CancellationToken cancellationToken);
        Task<int> Update(
            AdvertisementUpdateDto request, 
            CancellationToken cancellationToken);
        Task Delete(
            int id,
            CancellationToken cancellationToken);
        Task Restore(
            int id,
            CancellationToken cancellationToken);
        Task<AdvertisementDto> GetById(
            int id, 
            CancellationToken cancellationToken);
        Task<Paged.Response<AdvertisementPagedDto>> GetPaged(
            Paged.Request request, 
            CancellationToken cancellationToken);
        Task<Paged.Response<AdvertisementPagedDto>> GetPaged(
            Expression<Func<Domain.Advertisement, bool>> predicate,
            Paged.Request request,
            CancellationToken cancellationToken);
    }
}