﻿namespace Sev1.UserFiles.Application.Contracts.GetPaged
{
    public class GetPagedUserFileRequest : GetPagedRequest
    {
        public string SearchStr { get; set; }
        public string Tag { get; set; }
        public int? CategoryId { get; set; }
        public string UserId { get; set; }
    }
}