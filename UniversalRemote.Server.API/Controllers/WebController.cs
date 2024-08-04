using InputSimulatorStandard.Native;
using InputSimulatorStandard;
using Microsoft.AspNetCore.Mvc;
using UniversalRemote.Server.API.Models.DirectInput;
using WebSocketSharp.Server;
using UniversalRemote.Server.API.Models.Chrome;
using UniversalRemote.Server.API.Services;
using UniversalRemote.Server.API.Models.Settings;

namespace UniversalRemote.Server.API.Controllers
{
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
