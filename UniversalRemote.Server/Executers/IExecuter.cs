using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalRemote.Server.Loggers;

namespace UniversalRemote.Server.Executers
{
	public interface IExecuter
	{
		public ILogger Logger { get; }
		public Task ExecuteAsync(params string[] args);
	}
}
