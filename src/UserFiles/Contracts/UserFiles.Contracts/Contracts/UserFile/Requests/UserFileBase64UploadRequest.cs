using System.ComponentModel.DataAnnotations;

namespace Sev1.UserFiles.Contracts.Contracts.UserFile.Requests
{
    /// <summary>
    /// DTO одного файла при загрузке файлов в формате base64
    /// </summary>
    public sealed class UserFileBase64UploadRequest
    {
        /// <summary>
        /// Содержимое файла
        /// </summary>
        //[Required]
        public string ContentBase64 { get; set; }


        /// <summary>
        /// The raw Content-Type header of the uploaded file.
        /// </summary>
        //[Required]
        public string ContentType { get; set; }

        /// <summary>
        /// The raw Content-Disposition header of the uploaded file.
        /// </summary>
        //[Required]
        public string ContentDisposition { get; set; }

        /// <summary>
        /// The file length in bytes.
        /// </summary>
        //[Required]
        public long Length { get; set; }

        /// <summary>
        /// The form field name from the Content-Disposition header.
        /// </summary>
        //[Required]
        public string Name { get; set; }

        /// <summary>
        /// The file name from the Content-Disposition header.
        /// </summary>
        //[Required]
        public string FileName { get; set; }
    }
}