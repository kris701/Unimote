using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Unimote.Server.API.Helpers;
using Unimote.Server.API.Models.RemoteConfigurations;
using Unimote.Server.API.Models.Users;
using Unimote.Server.WPF.Helpers;
using Wpf.Ui.Controls;
using static Unimote.Server.API.APIDefinition;

namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class ConfigurationsViewModel : ObservableObject, INavigationAware
	{
		public void OnNavigatedTo() => InitializeViewModel();

		public void OnNavigatedFrom() { }

		internal void InitializeViewModel()
		{
			if (App.Server == null)
			{
				Configurations = new List<RemoteConfiguration>();
				return;
			}

			if (App.Server.Database.RemoteConfigurations.Count == 0)
			{
				OnAddConfiguration();
				App.Server.Database.RemoteConfigurations = new List<RemoteConfiguration>(Configurations);
			}
			Configuration = App.Server.Database.RemoteConfigurations.First();
			Configurations = App.Server.Database.RemoteConfigurations.Clone();
		}

		[ObservableProperty]
		private IEnumerable<RemoteConfiguration> _configurations;

		[ObservableProperty]
		private RemoteConfiguration _configuration;

		[ObservableProperty]
		private double _loadingOpacity = 0.5;

		[ObservableProperty]
		private bool _isLoading = false;

		[ObservableProperty]
		private bool _isLoaded = true;

		[RelayCommand]
		private async Task OnSelectConfiguration(Guid iD)
		{
			await LoadingStart();
			Configuration = Configurations.First(x => x.ID == iD);
			LoadingStop();
		}

		private async Task LoadingStart()
		{
			IsLoading = true;
			IsLoaded = false;
			await Task.Delay(100);
		}

		private void LoadingStop()
		{
			IsLoading = false;
			IsLoaded = true;
		}

		[RelayCommand]
		private async Task OnAddConfiguration()
		{
			await LoadingStart();
			var tmp = Configurations.ToList();
			Configuration = new RemoteConfiguration(
				Guid.NewGuid(),
				"New Configuration",
				"Description",
				new List<ButtonConfiguration>());
			tmp.Add(Configuration);
			Configurations = tmp;
			LoadingStop();
		}

		[RelayCommand]
		private async Task OnSaveConfigurations()
		{
			await LoadingStart();
			App.Server.Database.RemoteConfigurations = new List<RemoteConfiguration>(Configurations);
			ServerHelper.RestartServer();
			LoadingStop();
		}

		[RelayCommand]
		private async Task OnDeleteConfiguration()
		{
			await LoadingStart();
			var tmp = Configurations.ToList();
			tmp.Remove(Configuration);
			Configurations = tmp;

			if (Configurations.Count() == 0)
				await OnAddConfiguration();
			else
				Configuration = Configurations.First();
			LoadingStop();
		}

		[RelayCommand]
		private void OnAddNewButton(EndpointDefinition def)
		{
			if (Configuration.Buttons == null)
				return;
		}
	}
}
