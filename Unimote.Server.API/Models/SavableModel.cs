using System.Text.Json;

namespace Unimote.Server.API.Models
{
	public class SavableModel
	{
		public string FileName { get; set; }

		public SavableModel(string fileName)
		{
			FileName = fileName;
		}

		public void Save() => File.WriteAllText(FileName, JsonSerializer.Serialize(this));
	}
}
