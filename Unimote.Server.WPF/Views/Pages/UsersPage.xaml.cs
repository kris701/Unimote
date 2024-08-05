using System;
using System.Collections.Generic;
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
	/// Interaction logic for Users.xaml
	/// </summary>
	public partial class UsersPage : INavigableView<UsersViewModel>
	{
		public UsersViewModel ViewModel { get; }

		public UsersPage(UsersViewModel viewModel)
		{
			ViewModel = viewModel;
			DataContext = this;

			InitializeComponent();
		}
	}
}
