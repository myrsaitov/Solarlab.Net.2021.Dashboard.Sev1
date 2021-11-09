﻿namespace Sev1.Accounts.Application.Contracts.Identity
{
    public static class CreateUser
    {
        public class Request
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }

        public class Response
        {
            public bool IsSuccess { get; set; }
            public string UserId { get; set; }
            public string[] Errors { get; set; }
        }
    }
}