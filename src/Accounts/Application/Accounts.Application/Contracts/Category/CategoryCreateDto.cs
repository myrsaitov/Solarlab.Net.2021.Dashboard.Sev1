namespace Sev1.Advertisements.Application.Contracts.Category
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}