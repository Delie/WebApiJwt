using WebApiJwt.TokenHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApiJwt
{
	public class Startup
	{
		public Startup(IHostingEnvironment env) {
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			TokenConfig config = new TokenConfig();
			app.UseJwtBearerAuthentication(new JwtBearerOptions()
			{
				AutomaticAuthenticate = true,
				AutomaticChallenge = true,
				TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.SecretKey)),
					ValidateIssuer = true,
					ValidIssuer = config.Issuer,
					ValidateAudience = true,
					ValidAudience = config.Audience,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				}
			});
			app.UseMvc();
		}
	}
}
