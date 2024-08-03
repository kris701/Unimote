using System.Windows;
using System.Windows.Input;

namespace UniversalRemote.Server
{
	/// <summary>
	/// Provides bindable properties and commands for the NotifyIcon. In this sample, the
	/// view model is assigned to the NotifyIcon in XAML. Alternatively, the startup routing
	/// in App.xaml.cs could have created this view model, and assigned it to the NotifyIcon.
	/// </summary>
	public class NotifyIconViewModel
	{
		/// <summary>
		/// Shows a window, if none is already open.
		/// </summary>
		public ICommand ShowWindowCommand
		{
			get
			{
				return new DelegateCommand
				{
					CommandAction = () =>
					{
						Application.Current.MainWindow = new MainWindow();
						Application.Current.MainWindow.Show();
					},
					CanExecuteFunc = () => Application.Current.MainWindow == null || Application.Current.MainWindow.Visibility == Visibility.Hidden
				};
			}
		}

		/// <summary>
		/// Hides the main window. This command is only enabled if a window is open.
		/// </summary>
		public ICommand HideWindowCommand
		{
			get
			{
				return new DelegateCommand
				{
					CommandAction = () => Application.Current.MainWindow.Hide(),
					CanExecuteFunc = () => Application.Current.MainWindow != null && Application.Current.MainWindow.Visibility == Visibility.Visible
				};
			}
		}

		public ICommand StartServerCommand
		{
			get
			{
				return new DelegateCommand
				{
					CommandAction = () => App.Server.Start(),
					CanExecuteFunc = () => !App.Server.IsRunning
				};
			}
		}

		public ICommand StopServerCommand
		{
			get
			{
				return new DelegateCommand
				{
					CommandAction = () => App.Server.Stop(),
					CanExecuteFunc = () => App.Server.IsRunning
				};
			}
		}


		/// <summary>
		/// Shuts down the application.
		/// </summary>
		public ICommand ExitApplicationCommand
		{
			get
			{
				return new DelegateCommand { CommandAction = () => Application.Current.Shutdown() };
			}
		}
	}
}
