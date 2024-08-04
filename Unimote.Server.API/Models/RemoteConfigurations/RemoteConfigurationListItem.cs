using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class RemoteConfigurationListItem
	{
		[Required]
		public Guid? ID { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Description { get; set; }
	}
}
