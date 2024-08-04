using InputSimulatorStandard;
using InputSimulatorStandard.Native;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using UniversalRemote.Server.API.Models.DirectInput;
using UniversalRemote.Server.API.Models.Settings;

namespace UniversalRemote.Server.API.Controllers
{
	[ApiController]
	[Route("direct")]
	public class DirectInputController : ControllerBase
	{
		private readonly ILogger<DirectInputController> _logger;
		private readonly SettingsModel _settings;
		private readonly InputSimulator _sim;

		public DirectInputController(ILogger<DirectInputController> logger, SettingsModel settings)
		{
			_logger = logger;
			_settings = settings;
			_sim = new InputSimulator();
		}

		[HttpPost("mouse/move")]
		public IActionResult MouseMove([FromBody] MouseMoveInput inputModel)
		{
			if (!_settings.EnableDirectControl)
				return BadRequest("Direct control is disabled!");
			_sim.Mouse.MoveMouseToPositionOnVirtualDesktop((double)inputModel.X!, (double)inputModel.Y!);
			return Ok();
		}

		[HttpPost("mouse/click")]
		public IActionResult MouseClick([FromBody] MouseClickInput inputModel)
		{
			if (!_settings.EnableDirectControl)
				return BadRequest("Direct control is disabled!");
			switch (inputModel.Button)
			{
				case MouseClickInput.ButtonTypes.Left: _sim.Mouse.LeftButtonClick(); break;
				case MouseClickInput.ButtonTypes.Right: _sim.Mouse.RightButtonClick(); break;
			}
			return Ok();
		}

		[HttpPost("keyboard/press")]
		public IActionResult KeyboardPress([FromBody] KeyboardPressInput inputModel)
		{
			if (!_settings.EnableDirectControl)
				return BadRequest("Direct control is disabled!");
			_sim.Keyboard.KeyPress(inputModel.KeyCode);
			return Ok();
		}

		[HttpPost("keyboard/text")]
		public IActionResult KeyboardWriteText([FromBody] KeyboardTextInput inputModel)
		{
			if (!_settings.EnableDirectControl)
				return BadRequest("Direct control is disabled!");
			_sim.Keyboard.TextEntry(inputModel.Text);
			return Ok();
		}
	}
}
