using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class GetRemoteConfigurationInput
	{
		[Required]
		public Guid? Guid { get; set; }
	}
}
