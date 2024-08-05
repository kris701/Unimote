using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.Settings;
using Unimote.Server.WPF.Helpers;
using Unimote.Server.WPF.Models;
using Wpf.Ui;
using Wpf.Ui.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class DashboardViewModel : ObservableObject, INavigationAware
	{
		public DashboardViewModel(ISnackbarService snackbarService)
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

		public void OnNavigatedTo()
		{
			InitializeViewModel();
		}

		public void OnNavigatedFrom() { }

		internal void InitializeViewModel()
		{
			if (App.Server == null || !App.Server.IsRunning)
			{
				Stats = new List<StatsItem>();
				ConnectedWebTabs = new List<WebConnectedItem>();
				return;
			}

			var statItems = new List<StatsItem>();
			var props = App.Server.Database.Statistics.GetType().GetProperties();
			foreach(var prop in props)
			{
				var name = StringHelpers.ToSentenceCase(prop.Name);
				var value = prop.GetValue(App.Server.Database.Statistics, null);
				if (prop != null)
					statItems.Add(new StatsItem()
					{
						Name = name,
						Value = $"{value}"
					});
			}

			if (!statItems.SequenceEqual(Stats))
				Stats = statItems;

			if (App.Server.Settings.EnableWebControl && App.Server.WebSocketService != null)
			{
				var connectedWebTabs = new List<WebConnectedItem>();
				foreach (var endpoint in App.Server.WebSocketService.Endpoints)
				{
					var sessions = App.Server.WebSocketService.GetSessionsForEndpoint(endpoint);
					foreach (var session in sessions)
						connectedWebTabs.Add(new WebConnectedItem()
						{
							Endpoint = endpoint,
							ID = session
						});
				}
				if (!connectedWebTabs.SequenceEqual(ConnectedWebTabs))
					ConnectedWebTabs = connectedWebTabs;
			}
			else
				ConnectedWebTabs = new List<WebConnectedItem>();
		}

		[ObservableProperty]
		public ICommand _startServerCommand;

		[ObservableProperty]
		public ICommand _stopServerCommand;

		[ObservableProperty]
		private SettingsModel _settings = App.Server.Settings;

		[ObservableProperty]
		private IEnumerable<StatsItem> _stats;

		[ObservableProperty]
		private IEnumerable<WebConnectedItem> _connectedWebTabs;
	}
}
