using System.Windows;
using System.Windows.Input;
using Unimote.Server.UserControls;

namespace Unimote.Server
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ICommand ShowLogWindow
		{
			get
			{
				return new DelegateCommand
				{
					CommandAction = () =>
					{
						MainGrid.Children.Clear();
						MainGrid.Children.Add(new LogView());
					}
				};
			}
		}

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			Application.Current.MainWindow.Hide();
		}
	}
}