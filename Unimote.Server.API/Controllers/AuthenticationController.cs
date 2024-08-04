﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unimote.Server.API.Models.Authentication;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.RemoteConfigurations;
using Unimote.Server.API.Models.Settings;
using Unimote.Server.API.Models.Web;
using Unimote.Server.API.Services;

namespace Unimote.Server.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("authentication")]
	public class AuthenticationController : ControllerBase
	{
		private readonly ILogger<AuthenticationController> _logger;
		private readonly DatabaseModel _database;

		public AuthenticationController(ILogger<AuthenticationController> logger, DatabaseModel database)
		{
			_logger = logger;
			_database = database;
		}

		[HttpPost("")]
		[AllowAnonymous]
		public IActionResult Authenticate([FromBody] AuthenticateInput inputModel)
		{
			var target = _database.Users.First(x => x.UserName == inputModel.Username && x.Password == inputModel.Password);
			if (target == null)
				return BadRequest("Username or password incorrect!");

			return Ok(new AuthenticationOutput()
			{
				Token = JWTService.GenerateJWTToken(target, _database.JWTSecret, _database.JWTTokenLifetime)
			});
		}
	}
}
