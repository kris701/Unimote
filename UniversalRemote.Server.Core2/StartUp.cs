using UniversalRemote.Server.API.Logging;

namespace UniversalRemote.Server.API
{
	public class StartUp
	{
		public IConfiguration Configuration { get; }
		public StartUp(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddControllers(options =>
			{
				options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "The field is required");
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{
			if (File.Exists("log.txt"))
				File.Delete("log.txt");
			loggerFactory.AddProvider(new StringLoggerProvider("log.txt"));

			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
