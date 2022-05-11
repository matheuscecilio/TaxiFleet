using Company.Consumers;
using Contracts;
using MassTransit;
using RabbitMQ.Client;

namespace TaxiFleet.Manager.Installers
{
    public static class TaxiEcoSmallInstaller
    {
        public static void InstallTaxiEcoSmall(
            this IRabbitMqBusFactoryConfigurator configurator,
            IBusRegistrationContext context
        )
        {
            configurator.ReceiveEndpoint("taxi-eco-small-queue", x =>
            {
                x.ConfigureConsumeTopology = false;

                x.ConfigureConsumer<TaxiEcoSmallConsumer>(context);

                x.Bind(nameof(TaxiFleetMessage), s =>
                {
                    s.RoutingKey = "taxi.eco.small";
                    s.ExchangeType = ExchangeType.Topic;
                });

                x.Bind(nameof(TaxiFleetMessage), s =>
                {
                    s.RoutingKey = "taxi.*.small";
                    s.ExchangeType = ExchangeType.Topic;
                });
            });
        }
    }
}
