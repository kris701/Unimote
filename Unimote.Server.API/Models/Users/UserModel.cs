using Unimote.Server.API.Helpers;

namespace Unimote.Server.API.Models.Users
{
	public class UserModel : ICloneable
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public List<AllowedSection> AllowedSections { get; set; }

		public UserModel(string userName, string password, List<AllowedSection> allowedSections)
		{
			UserName = userName;
			Password = password;
			AllowedSections = allowedSections;
		}

		public object Clone()
		{
			var allowedSections = AllowedSections.Clone();
			if (allowedSections is List<AllowedSection> sec)
				return new UserModel(UserName, Password, sec);
			throw new Exception("Could not clone user!");
		}
	}
}
