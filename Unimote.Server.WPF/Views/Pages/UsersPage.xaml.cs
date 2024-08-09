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
