using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace VivaAerobus.Aplication.Health.Impl
{
    public class ApiHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try 
            {
                return Task.FromResult(HealthCheckResult.Healthy($"Api is Up UTC time {DateTime.UtcNow}"));
            }
            catch (Exception ex) 
            {
                return Task.FromResult(HealthCheckResult.Unhealthy(exception: ex));
            }
        }
    }
}
