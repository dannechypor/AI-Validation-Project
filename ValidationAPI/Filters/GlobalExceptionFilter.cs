using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ValidationAPI.Filters;

public class GlobalExceptionFilter : ExceptionFilterAttribute 
{
    public override void OnException(ExceptionContext context)
    {
        if (!context.ExceptionHandled)
        {
            var exception = context.Exception;
            int statusCode;
            
            switch (exception)
            {
                case UnauthorizedAccessException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case ArgumentOutOfRangeException:
                case InvalidOperationException:
                case ArgumentException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            
            context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
        }
    }
}