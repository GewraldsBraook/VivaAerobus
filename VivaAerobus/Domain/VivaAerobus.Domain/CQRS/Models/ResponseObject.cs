namespace VivaAerobus.Domain.CQRS.Models
{
    public class ResponseObject<T>(bool result, T data)
    {
        public bool Result { get; } = result;

        public T Data { get; } = data;
    }
}
