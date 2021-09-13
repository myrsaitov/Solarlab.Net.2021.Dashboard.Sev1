using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.DataAccess.Base;
using Sev1.Advertisements.Domain;

namespace Sev1.Advertisements.DataAccess.Interfaces
{
    public interface IAdvertisementRepository : IRepository<Advertisement, int>
    {
        Task<Advertisement> FindByIdWithUserInclude(
            int id, 
            CancellationToken cancellationToken);
        Task<Advertisement> FindByIdWithUserAndTagsInclude(
            int id,
            CancellationToken cancellationToken);
        Task<Advertisement> FindByIdWithUserAndCategoryAndTags(
            int id, 
            CancellationToken cancellationToken);
        Task<Advertisement> FindByIdWithUserAndImages(
    int id,
    CancellationToken cancellationToken);
        Task<int> CountWithOutDeleted(CancellationToken cancellationToken);
        Task<int> CountWithOutDeleted(
            Expression<Func<Advertisement, bool>> predicate,
            CancellationToken cancellationToken);
        Task<IEnumerable<Advertisement>> GetPagedWithTagsAndOwnerAndCategoryInclude(
            int offset,
            int limit,
            CancellationToken cancellationToken);
        Task<IEnumerable<Advertisement>> GetPagedWithTagsAndOwnerAndCategoryInclude(
            Expression<Func<Advertisement, bool>> predicate,
            int offset,
            int limit,
            CancellationToken cancellationToken);
    }
}