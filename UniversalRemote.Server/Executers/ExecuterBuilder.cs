using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalRemote.Server.Loggers;

namespace UniversalRemote.Server.Executers
{
	public static class ExecuterBuilder
	{
		private static Dictionary<string, Func<ILogger,IExecuter>> _executers = new Dictionary<string, Func<ILogger,IExecuter>>()
		{
			{ "DirectInputExecuter", (l) => new DirectInputExecuter(l) },
		};

		public static IExecuter GetExecuter(string name, ILogger logger) => _executers[name](logger);
	}
}
