//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
namespace D20Tek.Services.Core.UnitTests
{
    [TestClass]
    public class ExceptionTests
    {
        [TestMethod]
        public void EntityAlreadyExistsException_Create()
        {
            // arrange

            // act
            var ex = new EntityAlreadyExistsException("Id", "1234");

            // assert
            Assert.IsNotNull(ex);
            Assert.AreEqual(ex.EntityIdName, "Id");
            Assert.AreEqual(ex.EntityIdValue, "1234");
            StringAssert.Contains(ex.Message, "Id");
            StringAssert.Contains(ex.Message, "1234");
        }

        [TestMethod]
        public void EntityNotFoundException_Create()
        {
            // arrange

            // act
            var ex = new EntityNotFoundException("Id", "1234");

            // assert
            Assert.IsNotNull(ex);
            Assert.AreEqual(ex.EntityIdName, "Id");
            Assert.AreEqual(ex.EntityIdValue, "1234");
            StringAssert.Contains(ex.Message, "Id");
            StringAssert.Contains(ex.Message, "1234");
        }
    }
}
