using InputSimulatorStandard;
using InputSimulatorStandard.Native;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using UniversalRemote.Server.API.Models.DirectInput;

namespace UniversalRemote.Server.API.Controllers
{
	[ApiController]
	[Route("direct")]
	public class DirectInputController : ControllerBase
	{
		private readonly ILogger<DirectInputController> _logger;
		private readonly InputSimulator _sim = new InputSimulator();

		public DirectInputController(ILogger<DirectInputController> logger)
		{
			_logger = logger;
		}

		[HttpPost("mouse/move")]
		public IActionResult MouseMove([FromQuery] MouseMoveInput inputModel)
		{
			_sim.Mouse.MoveMouseToPositionOnVirtualDesktop((double)inputModel.X!, (double)inputModel.Y!);
			return Ok();
		}

		[HttpPost("mouse/click")]
		public IActionResult MouseClick([FromQuery] MouseClickInput inputModel)
		{
			switch (inputModel.Button)
			{
				case MouseClickInput.ButtonTypes.Left: _sim.Mouse.LeftButtonClick(); break;
				case MouseClickInput.ButtonTypes.Right: _sim.Mouse.RightButtonClick(); break;
			}
			return Ok();
		}

		[HttpPost("keyboard/press")]
		public IActionResult KeyboardPress([FromQuery] KeyboardPressInput inputModel)
		{
			_sim.Keyboard.KeyPress((VirtualKeyCode)inputModel.KeyCode);
			return Ok();
		}

		[HttpPost("keyboard/text")]
		public IActionResult KeyboardWriteText([FromQuery] KeyboardTextInput inputModel)
		{
			_sim.Keyboard.TextEntry(inputModel.Text);
			return Ok();
		}
	}
}
