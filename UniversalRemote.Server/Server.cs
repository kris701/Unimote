using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace UniversalRemote.Server
{
	public class Server
	{
		public int Port { get; set; } = 42566;
		private WebSocketServer _socketServer;

		public Server()
		{
			_socketServer = new WebSocketServer($"ws://localhost:{Port}");
			_socketServer.AddWebSocketService<UniversalRemoteEndpoint>("/universalremote");
		}

		public void Start()
		{
			_socketServer.Start();
		}

		public void Stop()
		{
			_socketServer.Stop();
		}
	}
}
