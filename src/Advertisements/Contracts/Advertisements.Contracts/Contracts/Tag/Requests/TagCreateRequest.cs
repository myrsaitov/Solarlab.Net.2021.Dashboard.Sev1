﻿namespace Sev1.Advertisements.Contracts.Contracts.Tag.Requests
{
    /// <summary>
    /// DTO при создании тага
    /// </summary>
    public sealed class TagCreateRequest
    {
        /// <summary>
        /// Текс тага
        /// </summary>
        public string Body { get; set; }
    }
}