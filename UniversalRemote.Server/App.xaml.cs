using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using UniversalRemote.Server.Core;

namespace UniversalRemote.Server
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private TaskbarIcon _notifyIcon;

		public static UniversalRemoteServer Server = new UniversalRemoteServer();

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			_notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
		}

		protected override void OnExit(ExitEventArgs e)
		{
			_notifyIcon.Dispose();
			base.OnExit(e);
		}
	}

}
