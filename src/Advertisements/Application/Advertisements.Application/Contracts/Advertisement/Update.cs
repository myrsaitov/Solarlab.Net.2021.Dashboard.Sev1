using System;

namespace Sev1.Advertisements.Application.Contracts.Advertisement
{
    public class Update
    {
        public sealed class Request
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string[] TagBodies { get; set; }
        }
        public sealed class Response
        {
            public int Id { get; set; }
        }
    }
}