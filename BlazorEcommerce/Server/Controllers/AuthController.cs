﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
