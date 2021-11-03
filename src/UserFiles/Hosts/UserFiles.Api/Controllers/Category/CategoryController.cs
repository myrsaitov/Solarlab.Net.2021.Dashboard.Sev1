using Microsoft.AspNetCore.Mvc;
using Sev1.UserFiles.Application.Interfaces.Category;
using Sev1.UserFiles.Contracts.Authorization;

namespace Sev1.UserFiles.Api.Controllers.Category
{
    [Route("api/v1/categories")]
    [ApiController]
    public partial class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;
    }
}