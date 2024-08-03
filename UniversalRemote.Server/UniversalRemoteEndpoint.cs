using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalRemote.Server.Executers;
using UniversalRemote.Server.Loggers;
using WebSocketSharp.Server;
using WebSocketSharp;

namespace UniversalRemote.Server
{
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
