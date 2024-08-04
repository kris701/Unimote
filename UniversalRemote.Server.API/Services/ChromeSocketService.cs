using WebSocketSharp;
using WebSocketSharp.Server;

namespace UniversalRemote.Server.API.Services
{
	public class ChromeSocketService : WebSocketBehavior
	{
		public void SendMessage(string message) => Send(message);
	}
}
