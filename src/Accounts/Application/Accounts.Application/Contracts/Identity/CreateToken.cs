﻿namespace Sev1.Accounts.Application.Contracts.Identity
{
    public static class CreateToken
    {
        public class Request
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Response
        {
            public string Token { get; set; }
        }
    }
}