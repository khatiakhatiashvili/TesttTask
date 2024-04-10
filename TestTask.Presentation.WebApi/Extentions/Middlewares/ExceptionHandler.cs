using System.Diagnostics;
using System.Net;
using System.Text.Json;
using TestTask.Core.Application.Commons;
using TestTask.Core.Application.Exceptions;

namespace TestTask.Presentation.WebApi.Extentions.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        public ExceptionHandler(RequestDelegate next) =>
            (this.next) = (next);

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string titleText = "One or more validation errors occurred.";
            var statusCode = (int)HttpStatusCode.BadRequest;
            var traceId = Activity.Current?.Id ?? context?.TraceIdentifier;

            switch (exception)
            {
                case ApplicationBaseException e:
                    statusCode = (int)e.StatusCode;
                    break;
                case FluentValidation.ValidationException _:
                    break;
                case EntityAlreadyExistsException _:
                    titleText = "EntityAlreadyExistsException.";
                    break;
                case OperationCanceledException _:
                    titleText = "Operation Is Canceled.";
                    break;
                case Exception _:
                    exception = new Exception("Internal Server Error.");
                    titleText = "Internal Server Error.";
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(
            JsonSerializer.Serialize(Response.Failure(
                titleText: titleText,
                statusCode: statusCode,
                traceId: traceId,
                exception: exception
            )));
        }
    }
}

