using UniversalRemote.Server.Core.Loggers;

namespace UniversalRemote.Server.Core.Executers
{
	public static class ExecuterBuilder
	{
		private static readonly Dictionary<string, Func<ILogger, IExecuter>> _executers = new Dictionary<string, Func<ILogger, IExecuter>>()
		{
			{ "DirectInputExecuter", (l) => new DirectInputExecuter(l) },
		};

		public static IExecuter GetExecuter(string name, ILogger logger) => _executers[name](logger);
	}
}
