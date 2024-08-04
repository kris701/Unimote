using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using Unimote.Server.API;

namespace Unimote.Server
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static UniversalRemoteServer Server;
		private TaskbarIcon _notifyIcon;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			_notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
			Server = new UniversalRemoteServer("settings.json", "database.json");
			Server.Start();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			Server.Stop();
			_notifyIcon.Dispose();
			base.OnExit(e);
		}
	}

}
