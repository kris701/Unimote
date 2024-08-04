using UniversalRemote.Server.API.Models.Settings;
using UniversalRemote.Server.API.Services;

namespace UniversalRemote.Server.API
{
	public class UniversalRemoteServer
	{
		public SettingsModel Settings { get; set; }
		public ILogger<UniversalRemoteServer>? Logger { get; private set; }
		public int Port { get; set; } = 42566;
		public bool IsRunning { get; internal set; } = false;
		private IHost? _host;

		public UniversalRemoteServer(SettingsModel settings)
		{
			Settings = settings;
		}

		public void Start()
		{
			_host = CreateHostBuilder().Build();
			Logger = _host.Services.GetRequiredService<ILogger<UniversalRemoteServer>>();
			_host.StartAsync();
			IsRunning = true;
		}

		public void Stop()
		{
			if (_host != null)
			{
				_host.StopAsync();
				_host.WaitForShutdown();
				_host.Dispose();
			}
			IsRunning = false;
		}

		private IHostBuilder CreateHostBuilder()
		{
			var builder = Host.CreateDefaultBuilder();
			builder.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<StartUp>();
				webBuilder.UseUrls($"http://localhost:{Port}");
			});
			builder.ConfigureServices(servicesCollection => {
				servicesCollection.AddSingleton<SettingsModel>(Settings);
				servicesCollection.AddSingleton<WebSocketService>(new WebSocketService(Settings));
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
