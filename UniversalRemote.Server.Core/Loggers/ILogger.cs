namespace UniversalRemote.Server.Core.Loggers
{
	public interface ILogger
	{
		public enum LogType { Message, Warning, Error }
		public void Log(string message, LogType type);
		public string GetLogs();
	}
}
