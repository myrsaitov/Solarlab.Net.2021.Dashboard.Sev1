using System;

namespace Sev1.Accounts.Contracts.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AllowAnonymousAttribute : Attribute
    { }
}