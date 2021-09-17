﻿using System;

namespace Sev1.Advertisements.Application.Contracts.Advertisement
{
    public class AdvertisementUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string[] TagBodies { get; set; }
    }
}