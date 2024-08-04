using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class ButtonConfiguration
	{
		[Required]
		public Guid? ButtonID { get; set; }
		[Required]
		public string? TargetEndpoint { get; set; }
		[Required]
		public string? Body { get; set; }
	}
}
