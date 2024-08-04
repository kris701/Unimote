using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.Authentication
{
	public class AuthenticateInput
	{
		[Required]
		public string? Username { get; set; }

		[Required]
		public string? Password { get; set; }
	}
}
