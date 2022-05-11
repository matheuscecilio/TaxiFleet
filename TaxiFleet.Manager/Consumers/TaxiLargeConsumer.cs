namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;
    using Microsoft.Extensions.Logging;
    using System;

    public class TaxiLargeConsumer : IConsumer<TaxiFleetMessage>
    {
        private readonly ILogger<TaxiLargeConsumer> _logger;

        public TaxiLargeConsumer(ILogger<TaxiLargeConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TaxiFleetMessage> context)
        {
            _logger.LogInformation("Date: {0} - Class: TaxiLargeConsumer - Message: {1}", DateTime.UtcNow, context.Message.Value);
            return Task.CompletedTask;
        }
    }
}