using System;

namespace Sev1.Advertisements.Application.Contracts.Category
{
    public class Create
    {
        public sealed class Request
        {
            public string Name { get; set; }
            public int? ParentCategoryId { get; set; }
        }

        public sealed class Response
        {
            public int Id { get; set; }
        }
    }
}