using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Unimote.Server.API.APIDefinition;
using Unimote.Server.API.Models.DirectInput;
using Unimote.Server.API.Models.RemoteConfigurations;

namespace Unimote.Server.API
{
	public static class ButtonsDefinition
	{
		public class VirtualButton
		{
			public string Name { get; set; }
			public Guid ID { get; set; }

			public VirtualButton(string name, Guid iD)
			{
				Name = name;
				ID = iD;
			}
		}

		public static IEnumerable<VirtualButton> Buttons { get; } = new List<VirtualButton>()
		{
			new VirtualButton("up", new Guid("9ec45789-6cf2-4911-abae-3475b1430cd4")),
			new VirtualButton("down", new Guid("39e84a48-d1b9-4e15-a134-370ebe49f3d4")),
			new VirtualButton("left", new Guid("82803903-6c45-481f-a692-b7d77f58ee72")),
			new VirtualButton("right", new Guid("0ffde619-a017-42c1-8964-f19e0f1a219f")),
		};
	}
}
