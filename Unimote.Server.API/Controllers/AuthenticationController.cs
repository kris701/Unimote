using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unimote.Server.API.Models.Authentication;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.Settings;
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
		private readonly SettingsModel _settings;

		public AuthenticationController(ILogger<AuthenticationController> logger, DatabaseModel database, SettingsModel settings)
		{
			_logger = logger;
			_database = database;
			_settings = settings;
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
				Token = JWTService.GenerateJWTToken(target, _settings.JWTSecret, _settings.JWTTokenLifetime)
			});
		}
	}
}
