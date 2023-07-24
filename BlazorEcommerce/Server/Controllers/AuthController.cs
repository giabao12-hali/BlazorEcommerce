using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorEcommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthSvc _authSvc;

		public AuthController(IAuthSvc authSvc)
        {
			_authSvc = authSvc;
		}

		[HttpPost("register")]
		public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
		{
			var response = await _authSvc.Register(
				new User
				{
					Email = request.Email
				}, 
				request.Password);

			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpPost("login")]
		public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
		{
			var response = await _authSvc.Login(request.Email, request.Password);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpPost("change-password"), Authorize]
		public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var response = await _authSvc.ChangePassword(int.Parse(userId), newPassword);

			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
    }
}
