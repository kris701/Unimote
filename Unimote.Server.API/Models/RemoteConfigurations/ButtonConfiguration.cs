using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class ButtonConfiguration : ICloneable
	{
		[Required]
		public Guid? ButtonID { get; set; }
		[Required]
		public HttpEndpoint? TargetEndpoint { get; set; }
		[Required]
		public string? Body { get; set; }

		public ButtonConfiguration(Guid? buttonID, HttpEndpoint? targetEndpoint, string? body)
		{
			ButtonID = buttonID;
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
