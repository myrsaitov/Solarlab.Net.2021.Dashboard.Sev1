using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sev1.Advertisements.Application.Repositories
{
    public interface ITagRepository : IRepository<Domain.Tag, int>
    {
    }
}