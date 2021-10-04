using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Grafana.Loki;
using System.Threading.Tasks;

namespace CraftAI.Worker.Service
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.Console()
				.WriteTo.GrafanaLoki("http://localhost:3100")
				.Enrich.FromLogContext()
				.Enrich.WithProperty("instance", "worker_1")
				.Enrich.AtLevel(LogEventLevel.Error, e => e.WithProperty("level", nameof(LogEventLevel.Error)))
				.Enrich.AtLevel(LogEventLevel.Fatal, e => e.WithProperty("level", nameof(LogEventLevel.Fatal)))
				.CreateLogger();
			await CreateHostBuilder(args).Build().RunAsync();
		}

		// Additional configuration is required to successfully run gRPC on macOS.
		// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				}).UseSerilog();
	}
}
