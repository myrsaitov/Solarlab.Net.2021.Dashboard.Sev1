﻿namespace Sev1.Accounts.Application.Contracts.GetPaged
{
    public class GetPagedAccountRequest : GetPagedRequest
    {
        public string SearchStr { get; set; }
        public string Tag { get; set; }
        public int? CategoryId { get; set; }
        public string UserName { get; set; }
    }
}