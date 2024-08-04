using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class RemoteConfiguration : RemoteConfigurationListItem
	{
		[Required]
		public List<ButtonConfiguration>? Buttons { get; set; }
	}
}
