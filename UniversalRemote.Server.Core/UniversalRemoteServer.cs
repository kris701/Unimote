using UniversalRemote.Server.Core.Loggers;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace UniversalRemote.Server.Core
{
	public class UniversalRemoteServer
	{
		public ILogger Logger { get; private set; }
		public int Port { get; set; } = 42566;
		public bool IsRunning { get; internal set; } = false;
		private readonly WebSocketServer _socketServer;

		public UniversalRemoteServer()
		{
			Logger = new StringLogger();
			_socketServer = new WebSocketServer($"ws://localhost:{Port}");
			_socketServer.AddWebSocketService<UniversalRemoteEndpoint>("/universalremote", () => new UniversalRemoteEndpoint(Logger));
		}

		public void Start()
		{
			_socketServer.Start();
			IsRunning = true;
		}

		public void Stop()
		{
			_socketServer.Stop();
			IsRunning = false;
		}
	}
}
