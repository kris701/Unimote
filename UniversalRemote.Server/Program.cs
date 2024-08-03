using System;
using System.Net.Sockets;
using System.Net;
using WebSocketSharp;
using WebSocketSharp.Server;
using UniversalRemote.Server.Executers;
using UniversalRemote.Server.Loggers;

namespace UniversalRemote.Server
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var wssv = new WebSocketServer("ws://localhost:42566");

			wssv.AddWebSocketService<UniversalRemoteEndpoint>("/universalremote");
			wssv.Start();
			Console.ReadKey(true);
			wssv.Stop();
		}
	}

	public class UniversalRemoteEndpoint : WebSocketBehavior
	{
		private ILogger _logger;
		private ExecuterManager _manager;

		public UniversalRemoteEndpoint()
		{
			_logger = new StringLogger();
			_manager = new ExecuterManager(_logger);
		}

		protected override async void OnMessage(MessageEventArgs e)
		{
			await _manager.Execute(e.Data);
		}
	}
}