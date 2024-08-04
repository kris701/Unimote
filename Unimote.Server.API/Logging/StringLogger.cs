namespace Unimote.Server.API.Logging
{
	public class StringLogger : ILogger
	{
		private readonly string _categoryName;
		private readonly string _logFilePath;

		public StringLogger(string categoryName, string logFilePath)
		{
			_categoryName = categoryName;
			_logFilePath = logFilePath;
		}

		public bool IsEnabled(LogLevel logLevel) => true;

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			try
			{
				RecordMsg(logLevel, eventId, state, exception, formatter);
			}
			catch (Exception)
			{
				//this is being used in case of error 'the process cannot access the file because it is being used by another process', could not find a better way to resolve the issue
				RecordMsg(logLevel, eventId, state, exception, formatter);
			}
		}

		private void RecordMsg<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			string msg = $"{logLevel} :: {_categoryName} :: {formatter(state, exception)} :: {DateTime.Now}";
			using (var writer = File.AppendText(_logFilePath))
				writer.WriteLine(msg);
		}

		public IDisposable BeginScope<TState>(TState state) => new StringLoggerDisposable();
	}
}
