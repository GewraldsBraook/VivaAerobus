namespace VivaAerobus.Domain.CQRS.Models
{
    public class Error
    {
        public Exception Exception { get; }

        public string Code => Exception?.GetType().Name ?? string.Empty;

        public string Description => Exception?.Message ?? string.Empty;

        public string Trace => Exception?.StackTrace ?? string.Empty;

        public Error()
        {
        }

        public Error(Exception exception)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }
    }
}
