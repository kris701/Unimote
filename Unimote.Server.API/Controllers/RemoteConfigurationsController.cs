using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.RemoteConfigurations;

namespace Unimote.Server.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("configurations")]
	public class RemoteConfigurationsController : ControllerBase
	{
		private readonly ILogger<RemoteConfigurationsController> _logger;
		private readonly DatabaseModel _database;

		public RemoteConfigurationsController(ILogger<RemoteConfigurationsController> logger, DatabaseModel database)
		{
			_logger = logger;
			_database = database;
		}

		[HttpGet("")]
		public IActionResult GetAllRemoteConfigurations([FromQuery] GetRemoteConfigurationsInput inputModel)
		{
			var list = new List<RemoteConfigurationListItem>();
			foreach (var item in _database.RemoteConfigurations)
				list.Add(new RemoteConfigurationListItem(item.ID, item.Name, item.Description));
			return Ok(list);
		}

		[HttpGet("configuration")]
		public IActionResult GetRemoteConfiguration([FromQuery] GetRemoteConfigurationInput inputModel)
		{
			if (!_database.RemoteConfigurations.Any(x => x.ID == inputModel.Guid))
				return BadRequest("Remote Configuration not found!");
			return Ok(_database.RemoteConfigurations.First(x => x.ID == inputModel.Guid));
		}
	}
}
