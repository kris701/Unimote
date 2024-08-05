using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unimote.Server.WPF.Helpers
{
	public static class ServerHelper
	{
		public static void RestartServer()
		{
			if (App.Server == null)
				return;
			if (!App.Server.IsRunning)
				return;

			if (App.Server.IsRunning)
				App.Server.Stop();
			App.Server.Start();
		}
	}
}
