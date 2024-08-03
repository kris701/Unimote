using System.Text;
using static UniversalRemote.Server.Core.Loggers.ILogger;

namespace UniversalRemote.Server.Core.Loggers
{
	public class StringLogger : ILogger
	{
		private readonly List<string> _logs = new List<string>();
		public void Log(string message, LogType type)
		{
			var logEntry = $"{DateTime.Now} : {GetLogPrefix(type)} : {message}";
#if DEBUG
			Console.WriteLine(logEntry);
#endif
			_logs.Add(logEntry);
		}

		private string GetLogPrefix(LogType type)
		{
			switch (type)
			{
				case LogType.Message: return "MSG";
				case LogType.Warning: return "WRN";
				case LogType.Error: return "ERR";
			}
			throw new Exception("Invalid log type!");
		}

		public string GetLogs()
		{
			var sb = new StringBuilder();
			foreach (var log in _logs)
				sb.AppendLine(log);
			return sb.ToString();
		}
	}
}
