using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.DirectInput
{
	public class KeyboardTextInput
	{
		[Required]
		public string Text { get; set; }
	}
}
