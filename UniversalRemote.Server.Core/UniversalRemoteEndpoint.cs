using UniversalRemote.Server.Core.Executers;
using UniversalRemote.Server.Core.Loggers;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace UniversalRemote.Server.Core
{
	public class UniversalRemoteEndpoint : WebSocketBehavior
	{
		private readonly ExecuterManager _manager;

		public UniversalRemoteEndpoint(ILogger logger)
		{
			_manager = new ExecuterManager(logger);
		}

		protected override async void OnMessage(MessageEventArgs e)
		{
			await _manager.Execute(e.Data);
		}
	}
}
