using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
