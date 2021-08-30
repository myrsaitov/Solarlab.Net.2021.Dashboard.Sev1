using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.Domain;

namespace Sev1.Advertisements.Application.Repositories
{
    public interface ICategoryRepository : IRepository<Domain.Category, int>
    {
        public Task<Category> FindByIdWithParentAndChilds(int id, CancellationToken cancellationToken);
    }
}