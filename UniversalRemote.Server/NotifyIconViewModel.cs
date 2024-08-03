using System.Windows;
using System.Windows.Input;

namespace UniversalRemote.Server
{
	public class NotifyIconViewModel
	{
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

		public ICommand ExitApplicationCommand
		{
			get
			{
				return new DelegateCommand { CommandAction = () => Application.Current.Shutdown() };
			}
		}
	}
}
