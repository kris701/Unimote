using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.Settings;
using Unimote.Server.API.Models.Web;
using Unimote.Server.API.Services;

namespace Unimote.Server.API.Controllers
{
	[Authorize(Roles = "WebControl")]
	[ApiController]
	[Route("web")]
	public class WebController : ControllerBase
	{
		private readonly ILogger<WebController> _logger;
		private readonly SettingsModel _settings;
		private readonly DatabaseModel _database;
		private readonly WebSocketService _socketServer;

		public WebController(ILogger<WebController> logger, SettingsModel settings, WebSocketService socketServer, DatabaseModel database)
		{
			_logger = logger;
			_settings = settings;
			_socketServer = socketServer;
			_database = database;
		}

		[HttpPost("click")]
		public IActionResult ClickOnWebPage([FromBody] ClickOnWebPageInput inputModel)
		{
			if (!_settings.EnableWebControl)
				return BadRequest("Web control is disabled!");

			switch (inputModel.Browser)
			{
				case ClickOnWebPageInput.BrowserTypes.Chrome:
					if (!_socketServer.IsEndpointConnected("/chrome"))
						return BadRequest("Chrome service not started or connected!");
					_socketServer.SendMessageToEndpoint("/chrome", $"{inputModel.TargetTab};{inputModel.XPath};click");
					_database.Statistics.CommandsExecuted++;
					break;
			}

			return Ok();
		}
	}
}
