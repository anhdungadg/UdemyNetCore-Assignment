using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace WebApi.Helper
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            int responseCode;

            //if (exception is NotFoundException) code = HttpStatusCode.NotFound;
            //else if (exception is UnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (exception is BadRequestException) code = HttpStatusCode.BadRequest;
            //else if (exception is ForbiddenException) code = HttpStatusCode.Forbidden;
            //else if (exception is ConflictException) code = HttpStatusCode.Conflict;
            //else if (exception is UnprocessableEntityException) code = HttpStatusCode.UnprocessableEntity;
            //else if (exception is TooManyRequestsException) code = HttpStatusCode.TooManyRequests;
            //else if (exception is LockedException) code = HttpStatusCode.Locked;
            //else if (exception is PreconditionFailedException) code = HttpStatusCode.PreconditionFailed;
            //else if (exception is PreconditionRequiredException) code = HttpStatusCode.PreconditionRequired;
            //else if (exception is UnsupportedMediaTypeException) code = HttpStatusCode.UnsupportedMediaType;
            //else if (exception is RequestEntityTooLargeException) code = HttpStatusCode.RequestEntityTooLarge;
            //else if (exception is RequestUriTooLongException) code = HttpStatusCode.RequestUriTooLong;
            //else if (exception is TooManyRequestsException) code = HttpStatusCode.TooManyRequests;
            //else if (exception is ServiceUnavailableException) code = HttpStatusCode.ServiceUnavailable;

            switch (exception)
            {
                case AppException e:
                    // Custom application error
                    responseCode = (int)HttpStatusCode.BadRequest;
                    break;

                case KeyNotFoundException e:
                    responseCode = (int)HttpStatusCode.NotFound;
                    break;

                default: // Unhandled error
                    responseCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = exception?.Message });
            await response.WriteAsync(result);
        }

    }
}
