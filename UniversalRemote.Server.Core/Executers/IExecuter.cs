using UniversalRemote.Server.Core.Loggers;

namespace UniversalRemote.Server.Core.Executers
{
	public interface IExecuter
	{
		public ILogger Logger { get; }
		public Task ExecuteAsync(params string[] args);
	}
}
