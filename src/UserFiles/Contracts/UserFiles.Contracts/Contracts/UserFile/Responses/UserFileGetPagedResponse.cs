using System.Collections.Generic;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Responses
{
    public sealed class UserFileGetPagedResponse
    {
        public int? Total { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public IEnumerable<UserFileGetResponse> Items { get; set; }
    }
}