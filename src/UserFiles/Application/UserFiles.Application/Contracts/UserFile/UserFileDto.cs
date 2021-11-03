namespace Sev1.UserFiles.Application.Contracts.UserFile
{
    public class UserFileDto
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