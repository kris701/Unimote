using System.ComponentModel.DataAnnotations;

namespace UniversalRemote.Server.API.Models.DirectInput
{
	public class MoveMouseInput
	{
		[Required]
		[Range(0, 63000)]
		public double? X { get; set; }
		[Required]
		[Range(0, 63000)]
		public double? Y { get; set; }
	}
}
