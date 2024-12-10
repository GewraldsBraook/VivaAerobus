using VivaAerobus.Domain.CQRS.Models;
using System.Net;

namespace VivaAerobus.API.Common.Handlers.Impl
{
    public class ApiResponseRetriver : IApiResponseRetriver
    {
        public Func<Exception, HttpStatusCode> GetFunctionOnError()
        {
            return (Exception response) => HttpStatusCode.InternalServerError;
        }

        public Func<CommandResponse<T>, HttpStatusCode> GetFunctionOnSuccesCommand<T>()
        {
            return (CommandResponse<T> response) => HttpStatusCode.OK;
        }

        public Func<QueryResponse<T>, HttpStatusCode> GetFunctionOnSuccesQuery<T>()
        {
            return (QueryResponse<T> response) => HttpStatusCode.OK;
        }
    }
}
