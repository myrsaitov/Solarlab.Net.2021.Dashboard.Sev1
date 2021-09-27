using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Accounts.Application.Interfaces.Category;

namespace Sev1.Accounts.Api.Controllers.Category
{
    [Route("api/v1/categories")]
    [ApiController]
    [Authorize]
    public partial class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;
    }
}