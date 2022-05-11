using Company.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using TaxiFleet.Manager.Installers;

namespace TaxiFleet.Manager
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();

                        x.AddConsumer<TaxiLargeConsumer>(typeof(TaxiLargeConsumerDefinition));
                        x.AddConsumer<TaxiEcoLargeConsumer>(typeof(TaxiEcoLargeConsumerDefinition));
                        x.AddConsumer<TaxiSmallConsumer>(typeof(TaxiSmallConsumerDefinition));
                        x.AddConsumer<TaxiEcoSmallConsumer>(typeof(TaxiEcoSmallConsumerDefinition));

                        var configuration = hostContext.Configuration;
                        var host = configuration.GetSection("RabbitMq:Host").Value;
                        var username = configuration.GetSection("RabbitMq:Username").Value;
                        var password = configuration.GetSection("RabbitMq:Password").Value;

                        x.UsingRabbitMq((ctx, cfg) =>
                        {
                            cfg.InstallTaxiFleetMessage();
                            cfg.InstallTaxiEcoLarge(ctx);
                            cfg.InstallTaxiEcoSmall(ctx);
                            cfg.InstallTaxiLarge(ctx);
                            cfg.InstallTaxiSmall(ctx);

                            cfg.Host(host, "/", h =>
                            {
                                h.Username(username);
                                h.Password(password);
                            });

                            cfg.ConfigureEndpoints(ctx);
                        });
                    });

                    services
                        .AddOptions<MassTransitHostOptions>()
                        .Configure(options =>
                        {
                            // if specified, waits until the bus is started before
                            // returning from IHostedService.StartAsync
                            // default is false
                            options.WaitUntilStarted = true;
                        });

                            services.AddHostedService<Worker>();
                        });
    }
}
