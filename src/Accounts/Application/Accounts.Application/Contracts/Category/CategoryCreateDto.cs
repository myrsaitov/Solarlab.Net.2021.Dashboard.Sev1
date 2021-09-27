namespace Sev1.Accounts.Application.Contracts.Category
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}