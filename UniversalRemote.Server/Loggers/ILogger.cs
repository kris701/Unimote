using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalRemote.Server.Loggers
{
	public interface ILogger
	{
		public enum LogType { Message, Warning, Error }
		public void Log(string message, LogType type);
		public string GetLogs();
	}
}
