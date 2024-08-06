using System.Reflection;
using Unimote.Server.API.Models.DirectInput;
using Unimote.Server.API.Models.RemoteConfigurations;

namespace Unimote.Server.API
{
	public static class APIDefinition
	{
		public class EndpointDefinition
		{
			public HttpEndpoint Endpoint { get; set; }
			public List<PropertyInfo> Properties { get; set; }

			public EndpointDefinition(HttpEndpoint endpoint, List<PropertyInfo> properties)
			{
				Endpoint = endpoint;
				Properties = properties;
			}
		}

		public static IEnumerable<EndpointDefinition> Endpoints { get; } = new List<EndpointDefinition>()
		{
			new EndpointDefinition(
				new HttpEndpoint("direct", "mouse/move", HttpEndpoint.EndpointTypes.POST), 
				typeof(MouseMoveInput).GetProperties().ToList()),
			new EndpointDefinition(
				new HttpEndpoint("direct", "mouse/click", HttpEndpoint.EndpointTypes.POST),
				typeof(MouseClickInput).GetProperties().ToList()),
			new EndpointDefinition(
				new HttpEndpoint("direct", "keyboard/press", HttpEndpoint.EndpointTypes.POST),
				typeof(KeyboardPressInput).GetProperties().ToList()),
			new EndpointDefinition(
				new HttpEndpoint("direct", "keyboard/text", HttpEndpoint.EndpointTypes.POST),
				typeof(KeyboardTextInput).GetProperties().ToList()),
		};
	}
}
