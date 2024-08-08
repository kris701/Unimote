using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class ButtonConfiguration : ICloneable
	{
		private Guid? _buttonID = null;
		[Required]
		public Guid? ButtonID { 
			get => _buttonID;
			set
			{
				_buttonID = value;
				ButtonName = ButtonsDefinition.Buttons.First(x => x.ID == value).Name;
			}
		}
		[Required]
		[JsonIgnore]
		public string? ButtonName { get; private set; }
		[Required]
		public HttpEndpoint? TargetEndpoint { get; set; }
		[Required]
		public string? Body { get; set; }

		public ButtonConfiguration(Guid? buttonID, HttpEndpoint? targetEndpoint, string? body)
		{
			ButtonID = buttonID;
			ButtonName = ButtonsDefinition.Buttons.First(x => x.ID == buttonID).Name;
			TargetEndpoint = targetEndpoint;
			Body = body;
		}

		public object Clone()
		{
			if (TargetEndpoint == null)
				throw new ArgumentNullException();
			var tmp = TargetEndpoint.Clone();
			if (tmp is HttpEndpoint targetEndpoint)
				return new ButtonConfiguration(ButtonID, targetEndpoint, Body);
			throw new Exception("Could not clone!");
		}
	}
}
