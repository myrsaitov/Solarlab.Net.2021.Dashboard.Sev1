namespace Sev1.Advertisements.Application.Contracts.Tag
{
    public class Create
    {
        public sealed class Request
        {
            public string Body { get; set; }
        }

        public sealed class Response
        {
            public int Id { get; set; }
        }
    }
}