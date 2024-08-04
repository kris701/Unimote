using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Unimote.Server.UserControls
{
	/// <summary>
	/// Interaction logic for LogView.xaml
	/// </summary>
	public partial class LogView : UserControl
	{
		public LogView()
		{
			InitializeComponent();
		}

		private async void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			while (true)
			{
				if (File.Exists("log.txt"))
					LogTextBlock.Text = File.ReadAllText("log.txt");
				await Task.Delay(1000);
			}
		}
	}
}
