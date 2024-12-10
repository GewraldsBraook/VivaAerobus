namespace VivaAerobus.Domain.CQRS.Models
{
    public class QueryResponse<T> : BaseResponse<T>
    {
        public QueryResponse(ResponseObject<T> response, Error error)
        {
            base.Error = error;
            base.Result = response;
        }

        public QueryResponse() : this(new ResponseObject<T>(result: false, default), new Error())
        {
        }
    }
}
