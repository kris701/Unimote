using Unimote.Client.App.ViewModels.Pages;

namespace Unimote.Client.App.Views.Pages
{
	public partial class MainPage : ContentPage
	{
		public MainPageViewModel ViewModel { get; }

		public MainPage()
		{
			ViewModel = new MainPageViewModel();
			InitializeComponent();
		}
	}

}
