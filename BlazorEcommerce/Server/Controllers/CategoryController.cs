using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategorySvc _categorySvc;

		public CategoryController(ICategorySvc categorySvc)
        {
			_categorySvc = categorySvc;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
		{
			var result = await _categorySvc.GetCategories();
			return Ok(result);
		}
    }
}
