using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace WebAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = 500;

            switch(context.Exception)
            {
                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest; break;

                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound; break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError; break;
            }

            context.Result = new ContentResult 
            { 
                Content = context.Exception.Message,
                ContentType = "text/plain",
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
