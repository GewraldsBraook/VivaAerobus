namespace VivaAerobus.Domain.CQRS.Models
{
    public sealed class CommandResponse<T> : BaseResponse<T>
    {
        public CommandResponse(ResponseObject<T> response, Error error)
        {
            base.Error = error;
            base.Result = response;
        }

        public CommandResponse() : this(new ResponseObject<T>(result: false, default), new Error())
        {
        }
    }
}
