using InputSimulatorStandard;
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

		[HttpPost("move")]
		public IActionResult MoveMouse([FromQuery] MoveMouseInput inputModel)
		{
			_logger.LogWarning("test");
			_sim.Mouse.MoveMouseToPositionOnVirtualDesktop((double)inputModel.X!, (double)inputModel.Y!);
			return Ok();
		}
	}
}
