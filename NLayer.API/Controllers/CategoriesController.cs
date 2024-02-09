using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.core.Services;

namespace NLayer.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[ValidateFilterAttribute] bu şekilde yaparsak tüm endpointlere yerleştirmem gerekecek.Zor.Global ise program.cs'te yap. 
    public class CategoriesController :CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // api/categories/GetSingleCategoryByIdWithProducts/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }
    }
}
