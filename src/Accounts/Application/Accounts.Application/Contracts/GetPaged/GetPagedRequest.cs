namespace Sev1.Accounts.Application.Contracts.GetPaged
{
    public class GetPagedRequest
    {
        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 0;
    }
}