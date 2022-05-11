namespace Company.Consumers
{
    using MassTransit;

    public class TaxiEcoSmallConsumerDefinition :
        ConsumerDefinition<TaxiEcoSmallConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TaxiEcoSmallConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}