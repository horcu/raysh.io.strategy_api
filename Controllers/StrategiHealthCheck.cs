using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace raysh.io.strategy_api
{
    public class StrategyHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            // var lastProcess = InvoiceWorkerStatistics.GetLastProcessTime();
            // var timeAgo = DateTime.UtcNow.Subtract(lastProcess);
            // var data = new Dictionary<string, object> {
            //     { "Last process", lastProcess },
            //     { "Time ago", timeAgo }
            // } as IReadOnlyDictionary<string, object>;

            //if (lastProcess > DateTime.UtcNow.AddSeconds(-90))
            //{
                return Task.FromResult(
                    HealthCheckResult.Healthy("Processing queue"));
            //}

           // return Task.FromResult(
           //     HealthCheckResult.Unhealthy("Processing is stuck somewhere", null, data));
        }
    }
}
