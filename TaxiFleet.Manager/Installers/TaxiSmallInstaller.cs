using Company.Consumers;
using Contracts;
using MassTransit;
using RabbitMQ.Client;

namespace TaxiFleet.Manager.Installers
{
    public static class TaxiSmallInstaller
    {
        public static void InstallTaxiSmall(
            this IRabbitMqBusFactoryConfigurator configurator,
            IBusRegistrationContext context
        )
        {
            configurator.ReceiveEndpoint("taxi-small-queue", x =>
            {
                x.ConfigureConsumeTopology = false;

                x.ConfigureConsumer<TaxiSmallConsumer>(context);

                x.Bind(nameof(TaxiFleetMessage), s =>
                {
                    s.RoutingKey = "taxi.small";
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
