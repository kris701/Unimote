using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unimote.Server.API.Models.Settings;
using Unimote.Server.API.Models.Web;
using Unimote.Server.API.Services;

namespace Unimote.Server.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("web")]
	public class WebController : ControllerBase
	{
		private readonly ILogger<WebController> _logger;
		private readonly SettingsModel _settings;
		private readonly WebSocketService _socketServer;

		public WebController(ILogger<WebController> logger, SettingsModel settings, WebSocketService socketServer)
		{
			_logger = logger;
			_settings = settings;
			_socketServer = socketServer;
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
					break;
			}

			return Ok();
		}
	}
}
