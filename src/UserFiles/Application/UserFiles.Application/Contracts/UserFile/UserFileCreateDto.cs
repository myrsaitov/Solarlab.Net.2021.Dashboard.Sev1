namespace Sev1.UserFiles.Application.Contracts.UserFile
{
    public class UserFileCreateDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string OwnerId { get; set; }
        public string[] TagBodies { get; set; }
    }
}