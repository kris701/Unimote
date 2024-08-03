using System.Windows;

namespace UniversalRemote.Server
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void RefreshLogsButton_Click(object sender, RoutedEventArgs e)
		{
			LogField.Text = App.Server.Logger.GetLogs();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LogField.Text = App.Server.Logger.GetLogs();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			Application.Current.MainWindow.Hide();
		}
	}
}