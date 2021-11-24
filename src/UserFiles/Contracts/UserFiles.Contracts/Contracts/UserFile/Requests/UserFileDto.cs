using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Requests
{
    /// <summary>
    /// DTO одного файла при загрузке файлов
    /// </summary>
    public sealed class UserFileDto
    {
        /// <summary>
        /// Список файлов
        /// </summary>
        //[Required]
        public string ContentBase64 { get; set; }

        //public int? Id { get; set; }
        //public int? FileIdOnForm { get; set; }
        //public string TmpPreviewUri { get; set; }
        //public int? AdvertisementId { get; set; }
        //public string OwnerId { get; set; }

        //{"id":null,"fileIdOnForm":0,"tmpPreviewUri":{"changingThisBreaksApplicationSecurity":"blob:http://localhost:4200/0943b7c3-976f-458e-9c39-f9e904baeee1"},
        //"advertisementId":null,"ownerId":"","content":{}}
    }
}