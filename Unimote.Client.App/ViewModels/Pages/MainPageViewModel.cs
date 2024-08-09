using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Unimote.Client.App.ViewModels.Pages
{
	public partial class MainPageViewModel : ObservableObject
	{
		[ObservableProperty]
		private int _clicked = 0;

		[RelayCommand]
		private void OnTest()
		{
			Clicked++;
		}
	}
}
