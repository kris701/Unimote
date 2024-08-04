using System.Runtime;
using UniversalRemote.Server.API.Models.Settings;
using WebSocketSharp.Server;

namespace UniversalRemote.Server.API.Services
{
	public class WebSocketService
	{
		public int Port { get; set; } = 42570;

		private readonly WebSocketServer? _socketServer;

		public WebSocketService(SettingsModel settings)
		{
			if (settings.EnableWebControl)
			{
				_socketServer = new WebSocketServer($"ws://localhost:{Port}");
				_socketServer.AddWebSocketService<WebSocketBehaviourService>("/chrome");
				_socketServer.Start();
			}
		}

		public void SendMessageToEndpoint(string endpoint, string message)
		{
			_socketServer?.WebSocketServices[endpoint].Sessions.Broadcast(message);
		}

		public bool IsEndpointConnected(string endpoint)
		{
			return _socketServer?.WebSocketServices[endpoint].Sessions.ActiveIDs.Count() > 0;
		}
	}
}
