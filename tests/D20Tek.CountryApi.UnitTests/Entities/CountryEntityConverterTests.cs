//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.CountryApi.Entities.Converters;

namespace D20Tek.CountryApi.UnitTests.Entities
{
    [TestClass]
    public class CountryEntityConverterTests
    {
        [TestMethod]
        public void ToResponse_NullEntity()
        {
            // arrange
            var conv = new CountryEntityConverter();

            // act
            var result = conv.ToResponse(null);

            // assert
            Assert.IsNull(result);
        }
    }
}
