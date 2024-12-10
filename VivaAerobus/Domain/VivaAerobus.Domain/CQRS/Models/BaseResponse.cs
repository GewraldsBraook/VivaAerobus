namespace VivaAerobus.Domain.CQRS.Models
{
    public class BaseResponse<T>
    {
        public Error Error { get; set; }
        public bool Success => Result != null && Result.Result;
        public ResponseObject<T> Result { get; set; }
    }
}
