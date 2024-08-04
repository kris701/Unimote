using System.Text.Json;
using Unimote.Server.API.Models.RemoteConfigurations;
using Unimote.Server.API.Models.Users;

namespace Unimote.Server.API.Models.Database
{
	public class DatabaseModel
	{
		public string JWTSecret { get; set; }
		public int JWTTokenLifetime { get; set; }

		public List<UserModel> Users { get; set; }
		public List<RemoteConfiguration> RemoteConfigurations { get; set; }

		public DatabaseModel()
		{
			JWTSecret = "some secretsome secretsome secretsome secretsome secretsome secret";
			JWTTokenLifetime = 10000;
			Users = new List<UserModel>() {
				new UserModel("admin", "password")
			};
			RemoteConfigurations = new List<RemoteConfiguration>();
		}

		private static string databaseFileName = "data.json";
		public void Load()
		{
			if (File.Exists(databaseFileName))
			{
				var database = JsonSerializer.Deserialize<DatabaseModel>(File.ReadAllText(databaseFileName));
				if (database != null)
				{
					JWTSecret = database.JWTSecret;
					JWTTokenLifetime = database.JWTTokenLifetime;
					Users = database.Users;
					RemoteConfigurations = database.RemoteConfigurations;
				}
			}
		}

		public void Save()
		{
			File.WriteAllText(databaseFileName, JsonSerializer.Serialize(this));
		}
	}
}
