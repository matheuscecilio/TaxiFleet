using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaxiFleet.Manager
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine(DateTime.UtcNow);
                Console.WriteLine("Type routing key:");
                var value = Console.ReadLine();
                Console.WriteLine("------------------------------");

                var message = new TaxiFleetMessage
                {
                    Value = value
                };

                await _bus.Publish(
                    message, 
                    stoppingToken
                );
            }
        }
    }
}
