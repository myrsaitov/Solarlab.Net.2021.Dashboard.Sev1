namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Requests
{
    public sealed class UserFileGetPagedRequest
    {
        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 0;
        public string SearchStr { get; set; }
        public string Tag { get; set; }
        public int? CategoryId { get; set; }
        public string UserId { get; set; }
    }
}