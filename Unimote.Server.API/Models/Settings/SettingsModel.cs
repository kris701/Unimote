using System.Text.Json;

namespace Unimote.Server.API.Models.Settings
{
	public class SettingsModel
	{
		public string FileName { get; set; }
		public string JWTSecret { get; set; }
		public int JWTTokenLifetime { get; set; }
		public bool EnableDirectControl { get; set; }
		public bool EnableWebControl { get; set; }

		public SettingsModel(string fileName)
		{
			FileName = fileName;
			JWTSecret = "some secretsome secretsome secretsome secretsome secretsome secretsome secretsome secret";
			JWTTokenLifetime = 10000;
			EnableDirectControl = false;
			EnableWebControl = false;
		}

		public void Save() => File.WriteAllText(FileName, JsonSerializer.Serialize(this));
	}
}
