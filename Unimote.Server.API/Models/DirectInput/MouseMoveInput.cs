using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.DirectInput
{
	public class MouseMoveInput
	{
		[Required]
		[Range(0, 63000)]
		public double? X { get; set; }
		[Required]
		[Range(0, 63000)]
		public double? Y { get; set; }
	}
}
