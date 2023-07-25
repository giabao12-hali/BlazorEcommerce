using Microsoft.AspNetCore.Authorization;
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

		[HttpGet("admin"), Authorize(Roles = "Admin")]
		public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAdminCategories()
		{
			var result = await _categorySvc.GetAdminCategories();
			return Ok(result);
		}

		[HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
		public async Task<ActionResult<ServiceResponse<List<Category>>>> DeleteCategory(int id)
		{
			var result = await _categorySvc.DeleteCategory(id);
			return Ok(result);
		}

		[HttpPost("admin"), Authorize(Roles = "Admin")]
		public async Task<ActionResult<ServiceResponse<List<Category>>>> AddCategory(Category category)
		{
			var result = await _categorySvc.AddCategory(category);
			return Ok(result);
		}

		[HttpPut("admin"), Authorize(Roles = "Admin")]
		public async Task<ActionResult<ServiceResponse<List<Category>>>> UpdateCategory(Category category)
		{
			var result = await _categorySvc.UpdateCategory(category);
			return Ok(result);
		}
	}
}
