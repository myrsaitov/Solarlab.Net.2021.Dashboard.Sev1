using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sev1.UserFiles.Application.Contracts.UserFile
{
    public class UserFileCreateDto
    {
        [Required]
        public int AdvertisementId { get; set; }
        
        [Required]
        public List<IFormFile> Files { get; set; }

        [Required]
        public string BaseUrl { get; set; }
    }
}