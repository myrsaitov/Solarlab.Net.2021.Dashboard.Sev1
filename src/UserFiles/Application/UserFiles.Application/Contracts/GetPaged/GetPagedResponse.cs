using System.Collections.Generic;

namespace Sev1.UserFiles.Application.Contracts.GetPaged
{
    public class GetPagedResponse<T>
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}