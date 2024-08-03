using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalRemote.Server.Loggers;

namespace UniversalRemote.Server.Executers
{
	public class ExecuterManager
	{
		public ILogger Logger { get; set; }

		private Dictionary<string, IExecuter> _executers = new Dictionary<string, IExecuter>();

		public ExecuterManager(ILogger logger)
		{
			Logger = logger;
		}

		public async Task Execute(string message)
		{
			try
			{
				var split = message.Split(';');
				if (!_executers.ContainsKey(split[0]))
					_executers.Add(split[0], ExecuterBuilder.GetExecuter(split[0], Logger));
				await _executers[split[0]].ExecuteAsync(split[1..]);
			}
			catch (Exception ex)
			{
				Logger.Log($"Input message: {message}; Error: {ex.Message}", ILogger.LogType.Error);
			}
		}
	}
}
