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
			if (App.Server.Logger != null)
				LogField.Text = App.Server.GetStringLog();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (App.Server.Logger != null)
				LogField.Text = App.Server.GetStringLog();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			Application.Current.MainWindow.Hide();
		}
	}
}