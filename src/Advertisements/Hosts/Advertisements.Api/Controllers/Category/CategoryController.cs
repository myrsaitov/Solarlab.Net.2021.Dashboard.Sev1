using Microsoft.AspNetCore.Mvc;
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Contracts.Authorization;

namespace Sev1.Advertisements.Api.Controllers.Category
{
    [Route("api/v1/categories")]
    [ApiController]
    public partial class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;
    }
}