using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Sev1.Accounts.AppServices.Services.Identity.Interfaces;

namespace Sev1.Accounts.AppServices.Services.Identity.Implementations
{
    public partial class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityService(
            IHttpContextAccessor httpContextAccessor, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
    }
}
