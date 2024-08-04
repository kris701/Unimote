using InputSimulatorStandard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.DirectInput;
using Unimote.Server.API.Models.Settings;

namespace Unimote.Server.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("direct")]
	public class DirectInputController : ControllerBase
	{
		private readonly ILogger<DirectInputController> _logger;
		private readonly SettingsModel _settings;
		private readonly DatabaseModel _database;
		private readonly InputSimulator _sim;

		public DirectInputController(ILogger<DirectInputController> logger, SettingsModel settings, DatabaseModel database)
		{
			_logger = logger;
			_settings = settings;
			_database = database;
			_sim = new InputSimulator();
		}

		[HttpPost("mouse/move")]
		public IActionResult MouseMove([FromBody] MouseMoveInput inputModel)
		{
			if (!_settings.EnableDirectControl)
				return BadRequest("Direct control is disabled!");
			_sim.Mouse.MoveMouseToPositionOnVirtualDesktop((double)inputModel.X!, (double)inputModel.Y!);
			_database.Statistics.CommandsExecuted++;
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
			_database.Statistics.CommandsExecuted++;
			return Ok();
		}

		[HttpPost("keyboard/press")]
		public IActionResult KeyboardPress([FromBody] KeyboardPressInput inputModel)
		{
			if (!_settings.EnableDirectControl)
				return BadRequest("Direct control is disabled!");
			_sim.Keyboard.KeyPress(inputModel.KeyCode);
			_database.Statistics.CommandsExecuted++;
			return Ok();
		}

		[HttpPost("keyboard/text")]
		public IActionResult KeyboardWriteText([FromBody] KeyboardTextInput inputModel)
		{
			if (!_settings.EnableDirectControl)
				return BadRequest("Direct control is disabled!");
			_sim.Keyboard.TextEntry(inputModel.Text);
			_database.Statistics.CommandsExecuted++;
			return Ok();
		}
	}
}
