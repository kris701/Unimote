using System.Windows.Input;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.Settings;
using Unimote.Server.WPF.Helpers;

namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class DashboardViewModel : ObservableObject
	{
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

		[ObservableProperty]
		private SettingsModel _settings = App.Server.Settings;

		[ObservableProperty]
		private StatisticModel _stats = App.Server.Database.Statistics;
	}
}
