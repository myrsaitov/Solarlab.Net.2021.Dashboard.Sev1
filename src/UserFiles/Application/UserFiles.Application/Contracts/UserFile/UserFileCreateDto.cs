namespace Sev1.UserFiles.Application.Contracts.UserFile
{
    public class UserFileCreateDto
    {
        public string FileName { get; set; }
        public string FileDescription { get; set; }
        public string OwnerId { get; set; }
    }
}