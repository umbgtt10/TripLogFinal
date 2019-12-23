using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog
{
    [TestClass]
    public class NewEntryPageViewModelTests
    {
        private readonly Mock<ITripLogNavigation> tripLogNavigation;
        private readonly NewEntryPageViewModel testee;

        public NewEntryPageViewModelTests()
        {
            tripLogNavigation = new Mock<ITripLogNavigation>();
            testee = new NewEntryPageViewModel(tripLogNavigation.Object);
        }

        [TestMethod]
        public void Init_SetsAttributes()
        {
            // Arrange & Act
            testee.Init();

            // Assert
            Assert.AreEqual(1, testee.Rating);
            Assert.AreEqual(DateTime.Now.Date, testee.Date.Date);
        }

        [TestMethod]
        public void SaveCommandFired_TitleSet_CallsNavigate()
        {
            // Arrange
            testee.Title = "Location";

            // Act
            testee.SaveCommand.Execute(null);

            // Assert
            tripLogNavigation.Verify(m => m.PopAsync(), Times.Once);
        }
    }
}
