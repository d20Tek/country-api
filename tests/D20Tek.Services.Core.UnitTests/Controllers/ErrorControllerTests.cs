//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Services.Core.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace D20Tek.Services.Core.UnitTests.Controllers
{
    [TestClass]
    public class ErrorControllerTests
    {
        private const string _intancePath = "/api/v1/test";

        [TestMethod]
        [DataRow(StatusCodes.Status500InternalServerError, typeof(Exception), "Test 500 error code", "Internal Server Error", "/errors/unknown-error")]
        [DataRow(StatusCodes.Status501NotImplemented, typeof(NotImplementedException), "Test 501 error code", "Not Implemented", "/errors/operation-not-implemented")]
        [DataRow(StatusCodes.Status404NotFound, typeof(EntityNotFoundException), "Entity with foo = bar was not found in repository.", "Not Found", "/errors/resource-not-found")]
        [DataRow(StatusCodes.Status409Conflict, typeof(EntityAlreadyExistsException), "Entity with foo = bar already exists in this repository.", "Conflict", "/errors/resource-create-conflict")]
        [DataRow(StatusCodes.Status401Unauthorized, typeof(UnauthorizedAccessException), "Test 401 error code", "Not Authorized", "/errors/user-unauthorized")]
        [DataRow(StatusCodes.Status405MethodNotAllowed, typeof(MethodAccessException), "Test 405 error code", "Method Not Allowed", "/errors/not-allowed")]
        [DataRow(StatusCodes.Status400BadRequest, typeof(FormatException), "Test 400 error code", "Bad Request", "/errors/invalid-format")]
        [DataRow(StatusCodes.Status400BadRequest, typeof(ArgumentException), "Test 400 error code", "Bad Request", "/errors/invalid-argument")]
        [DataRow(StatusCodes.Status409Conflict, typeof(HttpResponseException), "Test Response Exception.", "Test Conflict", "/errors/test")]
        public void HandleError(int status, Type exceptionType, string details, string title, string errorType)
        {
            // arrange
            var ex = CreateTestException(exceptionType, details);
            var controller = new ErrorController()
            {
                ControllerContext = CreateControllerContext(ex)
            };

            // act
            var result = controller.HandleError();

            // assert
            var problemDetails = ValidateObjectResultValue(result, status);
            Assert.IsNotNull(problemDetails);
            Assert.AreEqual(details, problemDetails.Detail);
            Assert.AreEqual(_intancePath, problemDetails.Instance);
            Assert.AreEqual(status, problemDetails.Status);
            Assert.AreEqual(title, problemDetails.Title);
            Assert.AreEqual(errorType, problemDetails.Type);
        }

        private Exception CreateTestException(Type exceptionType, string details)
        {
            return exceptionType switch
            {
                var type when type == typeof(EntityNotFoundException) => new EntityNotFoundException("foo", "bar"),
                var type when type == typeof(EntityAlreadyExistsException) => new EntityAlreadyExistsException("foo", "bar"),
                var type when type == typeof(NotImplementedException) => new NotImplementedException(details),
                var type when type == typeof(UnauthorizedAccessException) => new UnauthorizedAccessException(details),
                var type when type == typeof(MethodAccessException) => new MethodAccessException(details),
                var type when type == typeof(FormatException) => new FormatException(details),
                var type when type == typeof(ArgumentException) => new ArgumentException(details),
                var type when type == typeof(HttpResponseException) => new HttpResponseException(details, StatusCodes.Status409Conflict, "Test Conflict", "/errors/test"),
                _ => new Exception(details),
            };
        }

        private ControllerContext CreateControllerContext(Exception exception)
        {
            var mockExceptionHandler = new Mock<IExceptionHandlerFeature>();
            mockExceptionHandler.Setup(p => p.Error).Returns(exception);
            mockExceptionHandler.Setup(p => p.Path).Returns(_intancePath);

            var mockFeatures = new Mock<IFeatureCollection>();
            mockFeatures.Setup(p => p.Get<IExceptionHandlerFeature>())
                        .Returns(mockExceptionHandler.Object);

            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(p => p.Features).Returns(mockFeatures.Object);

            return new ControllerContext
            {
                HttpContext = mockContext.Object,
            };
        }

        private ProblemDetails? ValidateObjectResultValue(IActionResult result, int statusCode)
        {
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ObjectResult));

            var objResult = result as ObjectResult;
            Assert.IsNotNull(objResult);
            Assert.AreEqual(statusCode, objResult.StatusCode);

            return objResult.Value as ProblemDetails;
        }
    }
}
