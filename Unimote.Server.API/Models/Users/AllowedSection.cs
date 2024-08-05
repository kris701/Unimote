namespace Unimote.Server.API.Models.Users
{
	public class AllowedSection : ICloneable
	{
		public string Name { get; set; }
		public bool IsAllowed { get; set; }

		public AllowedSection(string name, bool isAllowed)
		{
			Name = name;
			IsAllowed = isAllowed;
		}

		public object Clone() => new AllowedSection(Name, IsAllowed);
	}
}
