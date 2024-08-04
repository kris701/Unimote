using InputSimulatorStandard.Native;
using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.DirectInput
{
	public class KeyboardPressInput
	{
		[Required]
		public VirtualKeyCode KeyCode { get; set; }
	}
}
