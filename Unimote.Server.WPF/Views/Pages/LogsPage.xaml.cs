using System.IO;
using Unimote.Server.WPF.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.Views.Pages
{
	/// <summary>
	/// Interaction logic for LogsPage.xaml
	/// </summary>
	public partial class LogsPage : INavigableView<LogsViewModel>
	{
		public LogsViewModel ViewModel { get; }

		public LogsPage(LogsViewModel viewModel)
		{
			ViewModel = viewModel;
			DataContext = this;

			InitializeComponent();

			System.Windows.Threading.DispatcherTimer logUpdateTimer = new System.Windows.Threading.DispatcherTimer();
			logUpdateTimer.Tick += LogUpdateTimer_Tick;
			logUpdateTimer.Interval = new TimeSpan(0, 0, 1);
			logUpdateTimer.Start();
		}

		private void LogUpdateTimer_Tick(object sender, EventArgs e)
		{
			if (File.Exists("log.txt"))
			{
				var newText = File.ReadAllText("log.txt");
				if (ViewModel.LogText != newText)
					ViewModel.LogText = newText;
			}
		}
	}
}
