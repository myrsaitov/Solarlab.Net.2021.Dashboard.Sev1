namespace Sev1.UserFiles.Application.Contracts.Category
{
    public class CategoryDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}