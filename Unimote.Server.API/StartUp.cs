using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Unimote.Server.API.Logging;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.Settings;
using Unimote.Server.API.Services;

namespace Unimote.Server.API
{
	public class StartUp
	{
		public IConfiguration Configuration { get; }
		public SettingsModel Settings { get; }
		public DatabaseModel Database { get; }

		public StartUp(IConfiguration configuration, DatabaseModel database, SettingsModel settings)
		{
			Configuration = configuration;
			Database = database;
			Settings = settings;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var key = Encoding.ASCII.GetBytes(Settings.JWTSecret);
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Unimote API", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							},
							Scheme = "oauth2",
							Name = "Bearer",
							In = ParameterLocation.Header,

						},
						new List<string>()
					}
				});
			});
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

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
