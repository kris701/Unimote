using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
