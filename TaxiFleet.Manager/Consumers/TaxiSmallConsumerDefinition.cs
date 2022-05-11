namespace Company.Consumers
{
    using MassTransit;

    public class TaxiSmallConsumerDefinition 
        : ConsumerDefinition<TaxiSmallConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TaxiSmallConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}