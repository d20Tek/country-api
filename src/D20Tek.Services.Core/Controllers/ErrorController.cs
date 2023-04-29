//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D20Tek.Services.Core.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError()
        {
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return HandleException(exceptionHandlerFeature.Error, exceptionHandlerFeature.Path);
        }

        protected virtual ObjectResult HandleException(Exception exception, string instancePath)
        {
            return exception switch
            {
                EntityNotFoundException ex =>
                    Problem(ex.Message, instancePath, StatusCodes.Status404NotFound, "Not Found", "/errors/resource-not-found"),
                EntityAlreadyExistsException ex =>
                    Problem(ex.Message, instancePath, StatusCodes.Status409Conflict, "Conflict", "/errors/resource-create-conflict"),
                NotImplementedException ex =>
                    Problem(ex.Message, instancePath, StatusCodes.Status501NotImplemented, "Not Implemented", "/errors/operation-not-implemented"),
                UnauthorizedAccessException ex =>
                    Problem(ex.Message, instancePath, StatusCodes.Status401Unauthorized, "Not Authorized", "/errors/user-unauthorized"),
                MethodAccessException ex =>
                    Problem(ex.Message, instancePath, StatusCodes.Status405MethodNotAllowed, "Method Not Allowed", "/errors/not-allowed"),
                FormatException ex =>
                    Problem(ex.Message, instancePath, StatusCodes.Status400BadRequest, "Bad Request", "/errors/invalid-format"),
                ArgumentException ex =>
                    Problem(ex.Message, instancePath, StatusCodes.Status400BadRequest, "Bad Request", "/errors/invalid-argument"),
                HttpResponseException ex =>
                    Problem(ex.Message, instancePath, ex.StatusCode, ex.Title, ex.Type),
                _ => Problem(exception.Message, instancePath, StatusCodes.Status500InternalServerError, "Internal Server Error", "/errors/unknown-error"),
            };
        }
    }
}
