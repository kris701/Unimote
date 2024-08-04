using System.Windows.Controls;
using Unimote.Server.WPF.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.Views.Pages
{
	public partial class DashboardPage : INavigableView<DashboardViewModel>
	{
		public DashboardViewModel ViewModel { get; }

		public DashboardPage(DashboardViewModel viewModel)
		{
			ViewModel = viewModel;
			DataContext = this;

			InitializeComponent();

			System.Windows.Threading.DispatcherTimer webConnectionsUpdateTimer = new System.Windows.Threading.DispatcherTimer();
			webConnectionsUpdateTimer.Tick += WebConnectionsUpdateTimer_Tick;
			webConnectionsUpdateTimer.Interval = new TimeSpan(0, 0, 1);
			webConnectionsUpdateTimer.Start();
		}

		private void WebConnectionsUpdateTimer_Tick(object sender, EventArgs e)
		{
			if (App.Server == null || App.Server.WebSocketService == null)
				return;
			WebControlConnectionsPanel.Children.Clear();
			if (!ViewModel.Settings.EnableWebControl || !App.Server.IsRunning)
				return;

			foreach (var endpoint in App.Server.WebSocketService.Endpoints)
			{
				var sessions = App.Server.WebSocketService.GetSessionsForEndpoint(endpoint);
                foreach (var session in sessions)
                {
					WebControlConnectionsPanel.Children.Add(new Label() { Content = $"{endpoint} : {session}" });
				}
            }
		}
	}
}
