using Company.Consumers;
using Contracts;
using MassTransit;
using RabbitMQ.Client;

namespace TaxiFleet.Manager.Installers
{
    public static class TaxiEcoLargeInstaller
    {
        public static void InstallTaxiEcoLarge(
            this IRabbitMqBusFactoryConfigurator configurator,
            IBusRegistrationContext context
        )
        {
            configurator.ReceiveEndpoint("taxi-eco-large-queue", x =>
            {
                x.ConfigureConsumeTopology = false;

                x.ConfigureConsumer<TaxiEcoLargeConsumer>(context);

                x.Bind(nameof(TaxiFleetMessage), s =>
                {
                    s.RoutingKey = "taxi.eco.large";
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
