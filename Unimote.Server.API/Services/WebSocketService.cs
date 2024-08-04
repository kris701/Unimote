using Unimote.Server.API.Models.Settings;
using WebSocketSharp.Server;

namespace Unimote.Server.API.Services
{
	public class WebSocketService : IDisposable
	{
		public int Port { get; set; } = 42570;
		public List<string> Endpoints { get; } = new List<string>()
		{
			"/chrome"
		};

		private readonly WebSocketServer? _socketServer;

		public WebSocketService(SettingsModel settings)
		{
			if (settings.EnableWebControl)
			{
				_socketServer = new WebSocketServer($"ws://localhost:{Port}");
				foreach(var endpoint in Endpoints)
					_socketServer.AddWebSocketService<WebSocketBehaviourService>(endpoint);
				_socketServer.Start();
			}
		}

		public void SendMessageToEndpoint(string endpoint, string message)
		{
			_socketServer?.WebSocketServices[endpoint].Sessions.Broadcast(message);
		}

		public bool IsEndpointConnected(string endpoint)
		{
			if (_socketServer == null)
				return false;
			return _socketServer.WebSocketServices[endpoint].Sessions.ActiveIDs.Count() > 0;
		}

		public List<string> GetSessionsForEndpoint(string endpoint)
		{
			if (_socketServer == null)
				return new List<string>();
			return _socketServer.WebSocketServices[endpoint].Sessions.ActiveIDs.ToList();
		}

		public void Dispose()
		{
			_socketServer?.Stop();
		}
	}
}
