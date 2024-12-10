using MediatR;
using Microsoft.AspNetCore.Mvc;
using VivaAerobus.API.Common.Handlers;
using VivaAerobus.API.Common.Handlers.Impl;
using VivaAerobus.Domain.CQRS.Models;
using System.Net;

namespace VivaAerobus.API.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        protected readonly IMediator _mediator;

        protected readonly Func<Exception, HttpStatusCode> _functionError;

        protected readonly IApiResponseRetriver _apiResponseRetriver;

        protected BaseController(ILogger loggger, IMediator mediator, IApiResponseRetriver apiResponseRetriver = null)
        {
            _logger = loggger;
            _mediator = mediator;
            apiResponseRetriver ??= new ApiResponseRetriver();
            _apiResponseRetriver = apiResponseRetriver;
            _functionError = apiResponseRetriver.GetFunctionOnError();
        }

        protected internal async Task<IActionResult> SendCommand<TC, TR>(TC command, Func<CommandResponse<TR>, HttpStatusCode> functionOnSucces = null, Func<Exception, HttpStatusCode> functionOnError = null) where TC : Command where TR : class
        {
            functionOnSucces ??= _apiResponseRetriver.GetFunctionOnSuccesCommand<TR>();
            functionOnError ??= _functionError;

            async Task<IActionResult> functionToRun()
            {
                CommandResponse<TR> commandResponse = await _mediator.Send((IRequest<CommandResponse<TR>>)command);
                return StatusCode(Convert.ToInt32(functionOnSucces(commandResponse)), commandResponse);
            }

            Task<IActionResult> resultInCaseOfError(Exception exception) => Task.Run((Func<IActionResult>)(() => StatusCode(Convert.ToInt32(functionOnError(exception)), new BaseResponse<Command>
            {
                Error = new Error(exception.InnerException)
            })));

            return await HandleAsync<IActionResult, BaseController>(functionToRun, resultInCaseOfError, "SendCommand");
        }

        protected internal async Task<IActionResult> SendQuery<TQ, TR>(TQ query, Func<QueryResponse<TR>, HttpStatusCode> functionOnSucces = null, Func<Exception, HttpStatusCode> functionOnError = null) where TQ : Query where TR : class
        {
            functionOnSucces ??= _apiResponseRetriver.GetFunctionOnSuccesQuery<TR>();
            functionOnError ??= _functionError;

            async Task<IActionResult> functionToRun()
            {
                QueryResponse<TR> queryResponse = await _mediator.Send((IRequest<QueryResponse<TR>>)query);
                return StatusCode(Convert.ToInt32(functionOnSucces(queryResponse)), queryResponse);
            }

            Task<IActionResult> resultInCaseOfError(Exception exception) => Task.Run((Func<IActionResult>)(() => StatusCode(Convert.ToInt32(functionOnError(exception)), new BaseResponse<Query>
            {
                Error = new Error(exception.InnerException)
            })));

            return await HandleAsync<IActionResult, BaseController>(functionToRun, resultInCaseOfError, "SendQuery");
        }

        protected internal async Task<R> HandleAsync<R, C>(Func<Task<R>> functionToRun, Func<Exception, Task<R>> resultInCaseOfError, string methodName = "")
        {
            try
            {
                Task<R> taskResult = functionToRun();

                while (!taskResult.IsCompleted) await Task.Delay(TimeSpan.FromMilliseconds(100.0));

                if (taskResult.Status == TaskStatus.Faulted) throw taskResult.Exception;

                return taskResult.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message} Type {FullName} Method {MethodName}", ex.Message, typeof(C).FullName, methodName);
                return await resultInCaseOfError(ex);
            }
        }
    }
}
