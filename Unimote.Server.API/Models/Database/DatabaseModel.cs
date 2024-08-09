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
		public List<AllowedSection> Sections { get; set; }

		public DatabaseModel(string fileName)
		{
			FileName = fileName;
			Sections = new List<AllowedSection>()
			{
				new AllowedSection("DirectControl", true),
				new AllowedSection("WebControl", true),
			};
			Users = new List<UserModel>() {
				new UserModel(Guid.NewGuid(), "admin", "password", new List<AllowedSection>(Sections))
			};
			RemoteConfigurations = new List<RemoteConfiguration>();
			Statistics = new StatisticModel();
		}

		public void Save() => File.WriteAllText(FileName, JsonSerializer.Serialize(this));
	}
}
