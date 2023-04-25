//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;

namespace D20Tek.CountryApi.UnitTests.Helpers
{
    internal static class ActionResultValidator
    {
        public static T ValidateOkResultValue<T>(ActionResult<T> result)
            where T : class
        {
            Assert.IsNotNull(result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var value = okResult.Value as T;
            Assert.IsNotNull(value);

            return value;
        }

        public static T ValidateCreatedAtResultValue<T>(ActionResult<T> result)
            where T : class
        {
            Assert.IsNotNull(result);
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.IsNotNull(createdResult);

            var value = createdResult.Value as T;
            Assert.IsNotNull(value);

            return value;
        }
    }
}
