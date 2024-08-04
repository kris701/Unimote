using System.Collections.ObjectModel;
using System.Windows.Input;
using Unimote.Server.WPF.Helpers;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.ViewModels.Windows
{
	public partial class MainWindowViewModel : ObservableObject
	{
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
				Content = "Data",
				Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
				TargetPageType = typeof(Views.Pages.DataPage)
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
		public ICommand _startServerCommand = new DelegateCommand
		{
			CommandAction = () => App.Server.Start(),
			CanExecuteFunc = () => App.Server != null && !App.Server.IsRunning
		};

		[ObservableProperty]
		public ICommand _stopServerCommand = new DelegateCommand
		{
			CommandAction = () => App.Server.Stop(),
			CanExecuteFunc = () => App.Server != null && App.Server.IsRunning
		};
	}
}
