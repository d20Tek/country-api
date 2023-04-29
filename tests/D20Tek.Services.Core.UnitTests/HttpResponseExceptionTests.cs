//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Http;

namespace D20Tek.Services.Core.UnitTests
{
    [TestClass]
    public class HttpResponseExceptionTests
    {
        [TestMethod]
        public void CreateFromDetails_Full()
        {
            // arrange

            // act
            var ex = new HttpResponseException("Test details", StatusCodes.Status400BadRequest, "Test", "/errors/test");

            // assert
            Assert.IsNotNull(ex);
            Assert.AreEqual("Test details", ex.Message);
            Assert.AreEqual(StatusCodes.Status400BadRequest, ex.StatusCode);
            Assert.AreEqual("Test", ex.Title);
            Assert.AreEqual("/errors/test", ex.Type);
        }

        [TestMethod]
        public void CreateFromDetails_Only()
        {
            // arrange

            // act
            var ex = new HttpResponseException("Test details");

            // assert
            Assert.IsNotNull(ex);
            Assert.AreEqual("Test details", ex.Message);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, ex.StatusCode);
            Assert.AreEqual("Internal Server Error", ex.Title);
            Assert.AreEqual("/errors/unknown-error", ex.Type);
        }

        [TestMethod]
        public void CreateFromException_Full()
        {
            // arrange
            var innerException = new ArgumentException("Test message");

            // act
            var ex = new HttpResponseException(innerException, StatusCodes.Status400BadRequest, "Test", "/errors/test");

            // assert
            Assert.IsNotNull(ex);
            Assert.AreEqual("Test message", ex.Message);
            Assert.AreEqual(StatusCodes.Status400BadRequest, ex.StatusCode);
            Assert.AreEqual("Test", ex.Title);
            Assert.AreEqual("/errors/test", ex.Type);
            Assert.IsNotNull(ex.InnerException);
        }

        [TestMethod]
        public void CreateFromException_Only()
        {
            // arrange
            var innerException = new ArgumentException("Test message");

            // act
            var ex = new HttpResponseException(innerException);

            // assert
            Assert.IsNotNull(ex);
            Assert.AreEqual("Test message", ex.Message);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, ex.StatusCode);
            Assert.AreEqual("Internal Server Error", ex.Title);
            Assert.AreEqual("/errors/unknown-error", ex.Type);
            Assert.IsNotNull(ex.InnerException);
        }
    }
}
