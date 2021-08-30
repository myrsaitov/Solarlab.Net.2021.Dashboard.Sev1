using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Services.Category.Interfaces;

namespace Sev1.API.Controllers.Category
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