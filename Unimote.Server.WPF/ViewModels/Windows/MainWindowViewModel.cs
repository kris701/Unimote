using System.Collections.ObjectModel;
using System.Windows.Input;
using Unimote.Server.WPF.Helpers;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.ViewModels.Windows
{
	public partial class MainWindowViewModel : ObservableObject
	{
		public MainWindowViewModel(ISnackbarService snackbarService)
		{
			_startServerCommand = new DelegateCommand
			{
				CommandAction = () => {
					App.Server.Start();
					snackbarService.Show(
						"Starting Started!",
						"All APIs should be available now.",
						ControlAppearance.Success,
						new SymbolIcon(SymbolRegular.ServerSurface16),
						TimeSpan.FromSeconds(2)
					);
				},
				CanExecuteFunc = () => App.Server != null && !App.Server.IsRunning
			};
			_stopServerCommand = new DelegateCommand
			{
				CommandAction = () => {
					App.Server.Stop();
					snackbarService.Show(
						"Starting Stopped!",
						"Server is now offline.",
						ControlAppearance.Success,
						new SymbolIcon(SymbolRegular.ServerSurface16),
						TimeSpan.FromSeconds(2)
					);
				},
				CanExecuteFunc = () => App.Server != null && App.Server.IsRunning
			};
		}

		[ObservableProperty]
		private string _applicationTitle = "Unimote Server";

		[ObservableProperty]
		private ObservableCollection<object> _menuItems = new()
		{
			new NavigationViewItem()
			{
				Content = "Home",
				Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
				TargetPageType = typeof(Views.Pages.DashboardPage)
			},
			new NavigationViewItem()
			{
				Content = "Logs",
				Icon = new SymbolIcon { Symbol = SymbolRegular.Document16 },
				TargetPageType = typeof(Views.Pages.LogsPage)
			}
		};

		[ObservableProperty]
		private ObservableCollection<object> _footerMenuItems = new()
		{
			new NavigationViewItem()
			{
				Content = "Settings",
				Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
				TargetPageType = typeof(Views.Pages.SettingsPage)
			}
		};

		[ObservableProperty]
		public ICommand _showWindowCommand = new DelegateCommand
		{
			CommandAction = () => Application.Current.MainWindow.Show(),
			CanExecuteFunc = () => Application.Current != null && (Application.Current.MainWindow == null || Application.Current.MainWindow.Visibility == Visibility.Hidden)
		};

		[ObservableProperty]
		public ICommand _hideWindowCommand = new DelegateCommand
		{
			CommandAction = () => Application.Current.MainWindow.Hide(),
			CanExecuteFunc = () => Application.Current != null && (Application.Current.MainWindow != null && Application.Current.MainWindow.Visibility == Visibility.Visible)
		};

		[ObservableProperty]
		public ICommand _exitApplicationCommand = new DelegateCommand
		{
			CommandAction = () => Application.Current.Shutdown()
		};

		[ObservableProperty]
		public ICommand _startServerCommand;

		[ObservableProperty]
		public ICommand _stopServerCommand;
	}
}
