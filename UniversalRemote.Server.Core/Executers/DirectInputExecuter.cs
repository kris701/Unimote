using InputSimulatorStandard;
using InputSimulatorStandard.Native;
using UniversalRemote.Server.Core.Loggers;

namespace UniversalRemote.Server.Core.Executers
{
	public class DirectInputExecuter : IExecuter
	{
		public ILogger Logger { get; }
		private readonly InputSimulator _sim = new InputSimulator();

		public DirectInputExecuter(ILogger logger)
		{
			Logger = logger;
		}

		public async Task ExecuteAsync(params string[] args)
		{
			switch (args[0])
			{
				case "Move": MoveMouse(args[1..]); break;
				case "LClick": _sim.Mouse.LeftButtonClick(); break;
				case "RClick": _sim.Mouse.RightButtonClick(); break;
				case "Key": ClickKey(args[1..]); break;
				case "String": WriteText(args[1..]); break;
			}
		}

		public void MoveMouse(string[] args)
		{
			var x = int.Parse(args[0]);
			var y = int.Parse(args[1]);
			_sim.Mouse.MoveMouseToPositionOnVirtualDesktop(x, y);
		}

		public void ClickKey(string[] args)
		{
			var key = int.Parse(args[0]);
			_sim.Keyboard.KeyPress((VirtualKeyCode)key);
		}

		public void WriteText(string[] args)
		{
			_sim.Keyboard.TextEntry(args[0]);
		}
	}
}
