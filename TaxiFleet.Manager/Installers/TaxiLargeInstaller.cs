using Company.Consumers;
using Contracts;
using MassTransit;
using RabbitMQ.Client;

namespace TaxiFleet.Manager.Installers
{
    public static class TaxiLargeInstaller
    {        
        public static void InstallTaxiLarge(
            this IRabbitMqBusFactoryConfigurator configurator,
            IBusRegistrationContext context
        )
        {
            configurator.ReceiveEndpoint("taxi-large-queue", x =>
            {
                x.ConfigureConsumeTopology = false;

                x.ConfigureConsumer<TaxiLargeConsumer>(context);

                x.Bind(nameof(TaxiFleetMessage), s =>
                {
                    s.RoutingKey = "taxi.large";
                    s.ExchangeType = ExchangeType.Topic;
                });

                x.Bind(nameof(TaxiFleetMessage), s =>
                {
                    s.RoutingKey = "taxi.*.large";
                    s.ExchangeType = ExchangeType.Topic;
                });
            });
        }
    }
}
