namespace Sev1.Advertisements.Application.Contracts.GetPaged
{
    public class GetPagedAdvertisementRequest : GetPagedRequest
    {
        public string SearchStr { get; set; }
        public string Tag { get; set; }
        public int? CategoryId { get; set; }
        public string UserName { get; set; }
    }
}