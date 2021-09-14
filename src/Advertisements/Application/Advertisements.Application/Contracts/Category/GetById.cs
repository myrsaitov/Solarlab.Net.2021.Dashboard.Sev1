namespace Sev1.Advertisements.Application.Contracts.Category
{
    public class GetById
    {
        public sealed class Request
        {
            public int Id { get; set; }
        }

        public sealed class Response
        {

            public int? Id { get; set; }
            public string Name { get; set; }
            public int? ParentCategoryId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}