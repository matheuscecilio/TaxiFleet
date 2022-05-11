namespace Company.Consumers
{
    using Contracts;
    using MassTransit;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class TaxiEcoSmallConsumer : IConsumer<TaxiFleetMessage>
    {
        private readonly ILogger<TaxiEcoSmallConsumer> _logger;

        public TaxiEcoSmallConsumer(ILogger<TaxiEcoSmallConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TaxiFleetMessage> context)
        {
            _logger.LogInformation("Date: {0} - Class: TaxiEcoSmallConsumer - Message: {1}", System.DateTime.UtcNow, context.Message.Value);
            return Task.CompletedTask;
        }
    }
}