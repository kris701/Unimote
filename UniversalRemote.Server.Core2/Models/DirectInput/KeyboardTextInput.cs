using System.ComponentModel.DataAnnotations;

namespace UniversalRemote.Server.API.Models.DirectInput
{
	public class KeyboardTextInput
	{
		[Required]
		public string Text { get; set; }
	}
}
