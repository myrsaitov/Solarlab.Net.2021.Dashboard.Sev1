﻿using System;
using Sev1.Advertisements.Application.Services.Contracts;

namespace Sev1.Advertisements.Application.Services.Advertisement.Contracts
{
    public class GetById
    {
        public sealed class Request
        {
            public int Id { get; set; }
        }

        public sealed class Response
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public decimal Price { get; set; }
            public string CreatedAt { get; set; }
            public int? CategoryId { get; set; }
            public bool IsDeleted { get; set; }
            public string[] Tags { get; set; }
        }
    }
}