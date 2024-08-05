using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.Settings;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class SettingsViewModel : ObservableObject, INavigationAware
	{
		private bool _isInitialized = false;

		[ObservableProperty]
		private SettingsModel _settings = App.Server.Settings;

		[ObservableProperty]
		private string _appVersion = String.Empty;

		[ObservableProperty]
		private ApplicationTheme _currentTheme = ApplicationTheme.Unknown;

		public void OnNavigatedTo()
		{
			if (!_isInitialized)
				InitializeViewModel();
		}

		public void OnNavigatedFrom() { }

		private void InitializeViewModel()
		{
			CurrentTheme = ApplicationThemeManager.GetAppTheme();
			AppVersion = $"Unimote Server UI - {GetAssemblyVersion()}";

			_isInitialized = true;
		}

		private string GetAssemblyVersion()
		{
			return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
				?? String.Empty;
		}

		[RelayCommand]
		private void OnRestartServer()
		{
			if (App.Server == null)
				return;
			if (!App.Server.IsRunning)
				return;

			if (App.Server.IsRunning)
				App.Server.Stop();
			App.Server.Start();
		}

		[RelayCommand]
		private void OnChangeTheme(string parameter)
		{
			switch (parameter)
			{
				case "theme_light":
					if (CurrentTheme == ApplicationTheme.Light)
						break;

					ApplicationThemeManager.Apply(ApplicationTheme.Light);
					CurrentTheme = ApplicationTheme.Light;

					break;

				default:
					if (CurrentTheme == ApplicationTheme.Dark)
						break;

					ApplicationThemeManager.Apply(ApplicationTheme.Dark);
					CurrentTheme = ApplicationTheme.Dark;

					break;
			}
		}
	}
}
