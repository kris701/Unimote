using System.Text.Json;
using Unimote.Server.API.Models.RemoteConfigurations;
using Unimote.Server.API.Models.Users;

namespace Unimote.Server.API.Models.Database
{
	public class DatabaseModel
	{
		public string FileName { get; set; }
		public List<UserModel> Users { get; set; }
		public List<RemoteConfiguration> RemoteConfigurations { get; set; }
		public StatisticModel Statistics { get; set; }

		public DatabaseModel(string fileName)
		{
			FileName = fileName;
			Users = new List<UserModel>() {
				new UserModel("admin", "password")
			};
			RemoteConfigurations = new List<RemoteConfiguration>();
			Statistics = new StatisticModel();
		}

		public void Save() => File.WriteAllText(FileName, JsonSerializer.Serialize(this));
	}
}
