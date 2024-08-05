using System.ComponentModel.DataAnnotations;
using Unimote.Server.API.Helpers;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class RemoteConfiguration : RemoteConfigurationListItem, ICloneable
	{
		[Required]
		public List<ButtonConfiguration>? Buttons { get; set; }

		public RemoteConfiguration(Guid? iD, string? name, string? description, List<ButtonConfiguration>? buttons) : base(iD, name, description)
		{
			Buttons = buttons;
		}

		public override object Clone()
		{
			if (Buttons == null)
				throw new ArgumentNullException();
			var tmp = Buttons.Clone();
			if (tmp is List<ButtonConfiguration> buttons)
				return new RemoteConfiguration(ID, Name, Description, buttons);
			throw new Exception("Could not clone!");
		}
	}
}
