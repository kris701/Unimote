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
		public int Port { get; set; } = 42570;

		private readonly ILogger<WebController> _logger;
		private readonly SettingsModel _settings;
		private readonly WebSocketServer? _socketServer;

		private readonly ChromeSocketService? _chromeService;

		public WebController(ILogger<WebController> logger, SettingsModel settings)
		{
			_logger = logger;
			_settings = settings;
			if (_settings.EnableWebControl)
			{
				_socketServer = new WebSocketServer($"ws://localhost:{Port}");
				_chromeService = new ChromeSocketService();
				_socketServer.AddWebSocketService<ChromeSocketService>("/chrome", () => _chromeService);
				_socketServer.Start();
			}
		}

		[HttpPost("click")]
		public IActionResult ClickOnWebPage([FromBody] ClickOnWebPageInput inputModel)
		{
			if (!_settings.EnableWebControl)
				return BadRequest("Web control is disabled!");
			if (_chromeService == null || _chromeService.State != WebSocketSharp.WebSocketState.Open)
				return BadRequest("Chrome service not started or connected!");

			switch (inputModel.TargetBrowser.ToUpper())
			{
				case "CHROME":
					_chromeService.SendMessage($"{inputModel.TargetTab};{inputModel.XPath}");
					break;
			}

			return Ok();
		}
	}
}
