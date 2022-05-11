namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;
    using Microsoft.Extensions.Logging;
    using System;

    public class TaxiEcoLargeConsumer : IConsumer<TaxiFleetMessage>
    {
        private readonly ILogger<TaxiEcoLargeConsumer> _logger;

        public TaxiEcoLargeConsumer(ILogger<TaxiEcoLargeConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TaxiFleetMessage> context)
        {
            _logger.LogInformation("Date: {0} - Class: TaxiEcoLargeConsumer - Message: {1}", DateTime.UtcNow, context.Message.Value);
            return Task.CompletedTask;
        }
    }
}