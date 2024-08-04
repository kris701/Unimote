using System.Text.Json;
using Unimote.Server.API.Models.RemoteConfigurations;
using Unimote.Server.API.Models.Users;

namespace Unimote.Server.API.Models.Database
{
	public class DatabaseModel : SavableModel
	{
		public List<UserModel> Users { get; set; }
		public List<RemoteConfiguration> RemoteConfigurations { get; set; }

		public DatabaseModel(string fileName) : base (fileName)
		{
			Users = new List<UserModel>() {
				new UserModel("admin", "password")
			};
			RemoteConfigurations = new List<RemoteConfiguration>();
		}
	}
}
