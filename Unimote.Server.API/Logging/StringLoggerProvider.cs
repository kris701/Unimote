namespace Unimote.Server.API.Logging
{
	public class StringLoggerProvider : ILoggerProvider
	{
		private readonly string _logFilePath;

		public StringLoggerProvider(string logFilePath)
		{
			_logFilePath = logFilePath;
		}

		public ILogger CreateLogger(string categoryName) => new StringLogger(categoryName, _logFilePath);

		public void Dispose()
		{
		}
	}
}
