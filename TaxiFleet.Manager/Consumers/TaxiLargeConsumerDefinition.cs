namespace Company.Consumers
{
    using MassTransit;

    public class TaxiLargeConsumerDefinition :
        ConsumerDefinition<TaxiLargeConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TaxiLargeConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}