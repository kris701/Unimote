namespace Unimote.Server.WPF.ViewModels.Pages
{
	public abstract partial class BaseLoadingPage : ObservableObject
	{
		[ObservableProperty]
		private bool _isLoading = false;

		[ObservableProperty]
		private bool _isLoaded = true;

		public async Task LoadingStart()
		{
			IsLoading = true;
			IsLoaded = false;
			await Task.Delay(100);
		}

		public void LoadingStop()
		{
			IsLoading = false;
			IsLoaded = true;
		}
	}
}
