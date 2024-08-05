﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using Unimote.Server.API;
using Unimote.Server.WPF.Services;
using Unimote.Server.WPF.ViewModels.Pages;
using Unimote.Server.WPF.ViewModels.Windows;
using Unimote.Server.WPF.Views.Pages;
using Unimote.Server.WPF.Views.Windows;
using Wpf.Ui;

namespace Unimote.Server.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		public static UniversalRemoteServer Server;
		public App()
		{
			Server = new UniversalRemoteServer("settings.json", "database.json");
		}

		// The.NET Generic Host provides dependency injection, configuration, logging, and other services.
		// https://docs.microsoft.com/dotnet/core/extensions/generic-host
		// https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
		// https://docs.microsoft.com/dotnet/core/extensions/configuration
		// https://docs.microsoft.com/dotnet/core/extensions/logging
		private static readonly IHost _host = Host
			.CreateDefaultBuilder()
			.ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
			.ConfigureServices((context, services) =>
			{
				services.AddHostedService<ApplicationHostService>();

				// Page resolver service
				services.AddSingleton<IPageService, PageService>();

				// Theme manipulation
				services.AddSingleton<IThemeService, ThemeService>();

				// TaskBar manipulation
				services.AddSingleton<ITaskBarService, TaskBarService>();

				// Service containing navigation, same as INavigationWindow... but without window
				services.AddSingleton<INavigationService, NavigationService>();

				services.AddSingleton<ISnackbarService, SnackbarService>();

				// Main window with navigation
				services.AddSingleton<INavigationWindow, MainWindow>();
				services.AddSingleton<MainWindowViewModel>();

				services.AddSingleton<DashboardPage>();
				services.AddSingleton<DashboardViewModel>();
				services.AddSingleton<LogsPage>();
				services.AddSingleton<LogsViewModel>();
				services.AddSingleton<UsersPage>();
				services.AddSingleton<UsersViewModel>();
				services.AddSingleton<SettingsPage>();
				services.AddSingleton<SettingsViewModel>();
			}).Build();

		/// <summary>
		/// Gets registered service.
		/// </summary>
		/// <typeparam name="T">Type of the service to get.</typeparam>
		/// <returns>Instance of the service or <see langword="null"/>.</returns>
		public static T GetService<T>()
			where T : class
		{
			return _host.Services.GetService(typeof(T)) as T;
		}

		/// <summary>
		/// Occurs when the application is loading.
		/// </summary>
		private void OnStartup(object sender, StartupEventArgs e)
		{
			_host.Start();
			Server.Start();
		}

		/// <summary>
		/// Occurs when the application is closing.
		/// </summary>
		private async void OnExit(object sender, ExitEventArgs e)
		{
			await _host.StopAsync();
			Server.Stop();
			_host.Dispose();
		}

		/// <summary>
		/// Occurs when an exception is thrown by an application but not handled.
		/// </summary>
		private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			// For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
		}
	}
}
