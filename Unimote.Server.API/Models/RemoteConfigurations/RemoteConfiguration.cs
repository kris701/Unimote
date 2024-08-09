using System.ComponentModel.DataAnnotations;

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
			var tmp = new List<ButtonConfiguration>();
			foreach (var button in Buttons)
				if (button.Clone() is ButtonConfiguration but)
					tmp.Add(but);
			return new RemoteConfiguration(ID, Name, Description, tmp);
		}
	}
}
