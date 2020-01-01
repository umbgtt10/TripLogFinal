using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using TripLog.Models;
using TripLog.Persistency;
using TripLog.Server.Controllers;

namespace TripLog.Server
{
    [TestClass]
    public class TripLogControllerTests
    {
        private readonly Mock<ILogger<TripLogController>> loggerMock;
        private readonly Mock<ITripLogPersistency> persistencyMock;
        private readonly TripLogController testee;

        public TripLogControllerTests()
        {
            loggerMock = new Mock<ILogger<TripLogController>>();
            persistencyMock = new Mock<ITripLogPersistency>();
            testee = new TripLogController(loggerMock.Object, persistencyMock.Object);
        }

        [TestMethod]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            persistencyMock.Setup(m => m.Retrieve()).Returns(Enumerable.Empty<TripLogEntry>);

            // Act
            var okResult = testee.Get();

            // Assert
            Assert.IsInstanceOfType(okResult.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Get_PersistencyFails_ReturnsInternalError()
        {
            // Arrange
            persistencyMock.Setup(m => m.Retrieve()).Throws(new Exception());

            // Act
            var internalErrorResult = testee.Get();

            // Assert
            Assert.AreEqual(500, ((ObjectResult)internalErrorResult.Result).StatusCode);
        }

        [TestMethod]
        public void Post_ReturnsOkResult()
        {
            // Arrange
            var expectedEntry = new TripLogEntry() { Title = "Title" };

            // Act
            var createdAtActionResult = testee.Post(expectedEntry);

            // Assert
            Assert.IsInstanceOfType(createdAtActionResult.Result, typeof(CreatedAtActionResult));
        }

        [TestMethod]
        public void Post_PersistencyFails_ReturnsInternalError()
        {
            // Arrange
            var expectedEntry = new TripLogEntry() { Title = "Title" };
            persistencyMock.Setup(m => m.Store(expectedEntry)).Throws(new Exception());

            // Act
            var internalErrorResult = testee.Post(expectedEntry);

            // Assert
            Assert.AreEqual(500, ((ObjectResult)internalErrorResult.Result).StatusCode);
        }

        [TestMethod]
        public void Delete_EntryMissing_ReturnsNotFoundObjectResult()
        {
            // Arrange
            var expectedEntry = new TripLogEntry() { Title = "Title" };
            persistencyMock.Setup(m => m.Delete(expectedEntry)).Returns(false);

            // Act
            var notFoundObjectResult = testee.Delete(expectedEntry);

            // Assert
            Assert.IsInstanceOfType(notFoundObjectResult, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void Delete_EntryPresent_ReturnsOkObjectResult()
        {
            // Arrange
            var expectedEntry = new TripLogEntry() { Title = "Title" };
            persistencyMock.Setup(m => m.Delete(expectedEntry)).Returns(true);

            // Act
            var okResult = testee.Delete(expectedEntry);

            // Assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
            Assert.AreEqual(expectedEntry, ((OkObjectResult)okResult).Value);
        }

        [TestMethod]
        public void Delete_PersistencyFails_ReturnsInternalError()
        {
            // Arrange
            var expectedEntry = new TripLogEntry() { Title = "Title" };
            persistencyMock.Setup(m => m.Delete(expectedEntry)).Throws(new Exception());

            // Act
            var internalErrorResult = testee.Delete(expectedEntry);

            // Assert
            Assert.AreEqual(500, ((ObjectResult)internalErrorResult).StatusCode);
        }
    }
}
