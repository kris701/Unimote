using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.Settings;
using Unimote.Server.API.Services;

namespace Unimote.Server.API
{
	public class UniversalRemoteServer
	{
		public delegate void StatusEventHandler();
		public event StatusEventHandler? OnServerStart;
		public event StatusEventHandler? OnServerStop;

		public SettingsModel Settings { get; }
		public DatabaseModel Database { get; }
		public WebSocketService? WebSocketService { get; internal set; }

		public ILogger<UniversalRemoteServer>? Logger { get; private set; }
		public int Port { get; set; } = 42566;
		public bool IsRunning { get; internal set; } = false;
		private IHost? _host;

		public UniversalRemoteServer(string settingsFile, string databaseFile)
		{
			Settings = new SettingsModel(settingsFile);
			if (File.Exists(settingsFile))
			{
				var settings = JsonSerializer.Deserialize<SettingsModel>(File.ReadAllText(settingsFile));
				if (settings != null)
					Settings = settings;
			}

			Database = new DatabaseModel(databaseFile);
			if (File.Exists(databaseFile))
			{
				var database = JsonSerializer.Deserialize<DatabaseModel>(File.ReadAllText(databaseFile));
				if (database != null)
					Database = database;
			}

			Settings.Save();
			Database.Save();
		}

		public void Start()
		{
			_host = CreateHostBuilder().Build();
			Logger = _host.Services.GetRequiredService<ILogger<UniversalRemoteServer>>();
			_host.StartAsync();
			IsRunning = true;
			OnServerStart?.Invoke();
		}

		public void Stop()
		{
			if (_host != null)
			{
				WebSocketService?.Dispose();
				_host.StopAsync();
				_host.Dispose();
			}
			Settings.Save();
			Database.Save();
			IsRunning = false;
			OnServerStop?.Invoke();
		}

		private IHostBuilder CreateHostBuilder()
		{
			var builder = Host.CreateDefaultBuilder();
			builder.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<StartUp>((w) => new StartUp(w.Configuration, Database, Settings));
				webBuilder.UseUrls($"http://localhost:{Port}");
			});
			builder.ConfigureServices(servicesCollection =>
			{
				servicesCollection.AddSingleton(Settings);
				WebSocketService = new WebSocketService(Settings);
				servicesCollection.AddSingleton(WebSocketService);
				servicesCollection.AddSingleton(Database);
			});
			return builder;
		}

		public string GetStringLog()
		{
			if (File.Exists("log.txt"))
				return File.ReadAllText("log.txt");
			return "Log is empty";
		}
	}
}
