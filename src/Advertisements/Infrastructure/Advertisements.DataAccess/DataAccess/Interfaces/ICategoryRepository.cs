using System.Threading;
using System.Threading.Tasks;
using Sev1.Advertisements.DataAccess.Base;
using Sev1.Advertisements.Domain;

namespace Sev1.Advertisements.DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        public Task<Category> FindByIdWithParentAndChilds(int id, CancellationToken cancellationToken);
    }
}