﻿namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class DashboardViewModel : ObservableObject
	{
		[ObservableProperty]
		private int _counter = 0;

		[RelayCommand]
		private void OnCounterIncrement()
		{
			Counter++;
		}
	}
}
