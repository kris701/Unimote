using Unimote.Server.API.Models.DirectInput;
using Unimote.Server.API.Models.RemoteConfigurations;

namespace Unimote.Server.API
{
	public static class APIDefinition
	{
		public class EndpointDefinition
		{
			public HttpEndpoint Endpoint { get; set; }
			public object Model { get; set; }

			public EndpointDefinition(HttpEndpoint endpoint, object model)
			{
				Endpoint = endpoint;
				Model = model;
			}
		}

		public static IEnumerable<EndpointDefinition> Endpoints { get; } = new List<EndpointDefinition>()
		{
			new EndpointDefinition(
				new HttpEndpoint("direct", "mouse/move", HttpEndpoint.EndpointTypes.POST),
				new MouseMoveInput(){ X = 0, Y = 0 }),
			new EndpointDefinition(
				new HttpEndpoint("direct", "mouse/click", HttpEndpoint.EndpointTypes.POST),
				new MouseClickInput() { Button = MouseClickInput.ButtonTypes.Left }),
			new EndpointDefinition(
				new HttpEndpoint("direct", "keyboard/press", HttpEndpoint.EndpointTypes.POST),
				new KeyboardPressInput() { KeyCode = InputSimulatorStandard.Native.VirtualKeyCode.SPACE }),
			new EndpointDefinition(
				new HttpEndpoint("direct", "keyboard/text", HttpEndpoint.EndpointTypes.POST),
				new KeyboardTextInput() { Text = "Sample Text" }),
		};
	}
}
