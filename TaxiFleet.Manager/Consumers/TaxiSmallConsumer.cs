namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;
    using Microsoft.Extensions.Logging;
    using System;

    public class TaxiSmallConsumer : IConsumer<TaxiFleetMessage>
    {
        private readonly ILogger<TaxiSmallConsumer> _logger;

        public TaxiSmallConsumer(ILogger<TaxiSmallConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TaxiFleetMessage> context)
        {
            _logger.LogInformation("Date: {0} - Class: TaxiSmallConsumer - Message: {1}", DateTime.UtcNow, context.Message.Value);
            return Task.CompletedTask;
        }
    }
}