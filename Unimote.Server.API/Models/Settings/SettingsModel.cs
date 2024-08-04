namespace Unimote.Server.API.Models.Settings
{
	public class SettingsModel : SavableModel
	{
		public string JWTSecret { get; set; }
		public int JWTTokenLifetime { get; set; }
		public bool EnableDirectControl { get; set; }
		public bool EnableWebControl { get; set; }

		public SettingsModel(string fileName) : base(fileName)
		{
			JWTSecret = "some secretsome secretsome secretsome secretsome secretsome secretsome secretsome secret";
			JWTTokenLifetime = 10000;
			EnableDirectControl = false;
			EnableWebControl = false;
		}
	}
}
