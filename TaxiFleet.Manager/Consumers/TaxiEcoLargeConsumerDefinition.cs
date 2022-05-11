namespace Company.Consumers
{
    using MassTransit;

    public class TaxiEcoLargeConsumerDefinition :
        ConsumerDefinition<TaxiEcoLargeConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TaxiEcoLargeConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}