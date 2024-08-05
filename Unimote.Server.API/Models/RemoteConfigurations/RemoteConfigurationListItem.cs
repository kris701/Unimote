using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class RemoteConfigurationListItem : ICloneable
	{
		[Required]
		public Guid? ID { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Description { get; set; }

		public RemoteConfigurationListItem(Guid? iD, string? name, string? description)
		{
			ID = iD;
			Name = name;
			Description = description;
		}

		public virtual object Clone() => new RemoteConfigurationListItem(ID, Name, Description);
	}
}
