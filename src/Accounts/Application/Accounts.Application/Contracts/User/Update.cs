﻿namespace Sev1.Accounts.Application.Contracts.User
{
    public static class Update
    {
        public class Request
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string UserName { get; set; }
        }
    }
}
