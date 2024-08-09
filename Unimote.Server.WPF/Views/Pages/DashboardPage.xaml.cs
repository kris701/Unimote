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
			ViewModel.InitializeViewModel();
		}
	}
}
