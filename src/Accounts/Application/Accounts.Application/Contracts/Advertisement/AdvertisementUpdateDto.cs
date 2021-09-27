namespace Sev1.Accounts.Application.Contracts.Account
{
    public class AccountUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string[] TagBodies { get; set; }
    }
}