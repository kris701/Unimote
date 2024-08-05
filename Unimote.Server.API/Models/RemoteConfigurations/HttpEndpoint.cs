using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.RemoteConfigurations
{
	public class HttpEndpoint : ICloneable
	{
		public enum EndpointTypes { POST, GET }

		[Required]
		public string? Category { get; set; }
		[Required]
		public string? Endpoint { get; set; }
		[Required]
		public EndpointTypes? EndpointType { get; set; }

		public HttpEndpoint(string? category, string? endpoint, EndpointTypes? endpointType)
		{
			Category = category;
			Endpoint = endpoint;
			EndpointType = endpointType;
		}

		public object Clone() => new HttpEndpoint(Category, Endpoint, EndpointType);
	}
}
