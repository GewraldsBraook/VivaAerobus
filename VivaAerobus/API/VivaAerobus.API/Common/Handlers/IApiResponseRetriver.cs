using VivaAerobus.Domain.CQRS.Models;
using System.Net;

namespace VivaAerobus.API.Common.Handlers
{
    public interface IApiResponseRetriver
    {
        Func<CommandResponse<T>, HttpStatusCode> GetFunctionOnSuccesCommand<T>();

        Func<Exception, HttpStatusCode> GetFunctionOnError();

        Func<QueryResponse<T>, HttpStatusCode> GetFunctionOnSuccesQuery<T>();
    }
}
