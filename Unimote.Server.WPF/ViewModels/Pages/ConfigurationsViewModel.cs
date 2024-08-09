using System.Text.Json;
using Unimote.Server.API;
using Unimote.Server.API.Models.RemoteConfigurations;
using Unimote.Server.WPF.Helpers;
using Wpf.Ui.Controls;
using static Unimote.Server.API.APIDefinition;

namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class ConfigurationsViewModel : BaseLoadingPage, INavigationAware
	{
		public void OnNavigatedTo() => InitializeViewModel();

		public void OnNavigatedFrom() { }

		internal void InitializeViewModel()
		{
			Configurations = new List<RemoteConfiguration>();
			if (App.Server == null)
				return;

			if (App.Server.Database.RemoteConfigurations.Count == 0)
			{
				Configuration = new RemoteConfiguration(
					Guid.NewGuid(),
					"New Configuration",
					"Description",
					new List<ButtonConfiguration>());
				Configurations = new List<RemoteConfiguration>() {
					Configuration
				};
				App.Server.Database.RemoteConfigurations = new List<RemoteConfiguration>(Configurations);
			}
			foreach (var config in App.Server.Database.RemoteConfigurations)
				if (config.Clone() is RemoteConfiguration rconfig)
					Configurations.Add(rconfig);
			Configuration = Configurations.First();
		}

		[ObservableProperty]
		private List<RemoteConfiguration> _configurations;

		[ObservableProperty]
		private RemoteConfiguration _configuration;

		[RelayCommand]
		private async Task OnSelectConfiguration(Guid iD)
		{
			await LoadingStart();
			Configuration = Configurations.First(x => x.ID == iD);
			LoadingStop();
		}

		[RelayCommand]
		private async Task OnAddConfiguration()
		{
			await LoadingStart();
			Configuration = new RemoteConfiguration(
				Guid.NewGuid(),
				"New Configuration",
				"Description",
				new List<ButtonConfiguration>());
			Configurations.Insert(0, Configuration);
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
			Configurations.Remove(Configuration);

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

			var cpy = Configuration.Clone();
			if (cpy is RemoteConfiguration config)
			{
				Configurations.Remove(Configuration);
				config.Buttons.Add(
					new ButtonConfiguration(
						Guid.NewGuid(),
						ButtonsDefinition.Buttons.First().ID,
						def.Endpoint,
						JsonSerializer.Serialize(def.Model, new JsonSerializerOptions() { WriteIndented = true })));
				Configuration = config;
				Configurations.Insert(0, Configuration);
			}
		}

		[RelayCommand]
		private void OnDeleteEndpoint(Guid? id)
		{
			if (Configuration.Buttons == null)
				return;

			var cpy = Configuration.Clone();
			if (cpy is RemoteConfiguration config)
			{
				Configurations.Remove(Configuration);
				config.Buttons.RemoveAll(x => x.ID == id);
				Configuration = config;
				Configurations.Insert(0, Configuration);
			}
		}

		[RelayCommand]
		private void OnButtonSelectedForEndpoint(object objs)
		{
			if (Configuration.Buttons == null)
				return;

			if (objs is object[] ids && ids.Length == 2)
			{
				var buttonID = new Guid($"{ids[0]}");
				var configID = new Guid($"{ids[1]}");

				var cpy = Configuration.Clone();
				if (cpy is RemoteConfiguration config)
				{
					Configurations.Remove(Configuration);
					var target = config.Buttons.SingleOrDefault(x => x.ID == configID);
					if (target is ButtonConfiguration button)
						button.ButtonID = buttonID;
					Configuration = config;
					Configurations.Insert(0, Configuration);
				}
			}
		}
	}
}
