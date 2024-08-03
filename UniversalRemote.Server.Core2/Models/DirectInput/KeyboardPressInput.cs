using InputSimulatorStandard.Native;
using System.ComponentModel.DataAnnotations;

namespace UniversalRemote.Server.API.Models.DirectInput
{
	public class KeyboardPressInput
	{
		[Required]
		public VirtualKeyCode KeyCode { get; set; }
	}
}
