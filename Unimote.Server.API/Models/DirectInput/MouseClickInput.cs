using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.DirectInput
{
	public class MouseClickInput
	{
		public enum ButtonTypes { Left, Right }
		[Required]
		public ButtonTypes? Button { get; set; }
	}
}
