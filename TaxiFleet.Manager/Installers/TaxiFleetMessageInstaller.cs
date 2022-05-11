using Contracts;
using MassTransit;
using RabbitMQ.Client;

namespace TaxiFleet.Manager.Installers
{
    public static class TaxiFleetMessageInstaller
    {   
        public static void InstallTaxiFleetMessage(
            this IRabbitMqBusFactoryConfigurator configurator
        )
        {
            configurator.Send<TaxiFleetMessage>(x => x.UseRoutingKeyFormatter(c => c.Message.Value));

            configurator.Message<TaxiFleetMessage>(m => m.SetEntityName(nameof(TaxiFleetMessage)));

            configurator.Publish<TaxiFleetMessage>(p =>
            {
                p.ExchangeType = ExchangeType.Topic;
            });
        }
    }
}
