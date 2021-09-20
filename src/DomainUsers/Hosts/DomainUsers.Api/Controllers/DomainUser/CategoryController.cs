﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.DomainUsers.Application.Interfaces.DomainUser;

namespace Sev1.DomainUsers.Api.Controllers.DomainUser
{
    [Route("api/v1/categories")]
    [ApiController]
    [Authorize]
    public partial class DomainUserController : ControllerBase
    {
        private readonly IDomainUserService _domainUserService;
        public DomainUserController(IDomainUserService domainUserService) => _domainUserService = domainUserService;
    }
}