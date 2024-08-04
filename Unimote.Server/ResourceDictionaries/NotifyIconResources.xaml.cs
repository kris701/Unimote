using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Unimote.Server;

namespace Unimote.Server.ResourceDictionaries
{
	public partial class NotifyIconResources
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
					CanExecuteFunc = () => Application.Current != null && (Application.Current.MainWindow == null || Application.Current.MainWindow.Visibility == Visibility.Hidden)
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
					CanExecuteFunc = () => Application.Current != null && (Application.Current.MainWindow != null && Application.Current.MainWindow.Visibility == Visibility.Visible)
				};
			}
		}

		public ICommand ExitApplicationCommand
		{
			get
			{
				return new DelegateCommand
				{
					CommandAction = () => Application.Current.Shutdown()
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
					CanExecuteFunc = () => App.Server != null && !App.Server.IsRunning
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
					CanExecuteFunc = () => App.Server != null && App.Server.IsRunning
				};
			}
		}
	}
}
