using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;

namespace TripLog.Integration.Test
{
    [TestClass]
    public class TripLogIntegrationTests
    {
        private readonly Mock<ITripLogFactory> tripLogFactoryMock;
        private readonly Mock<ITripLogNavigation> tripLogNavigationMock;
        private readonly Mock<IGeoLocationService> geoLocationServiceMock;
        private readonly RestTripLogDataService tripLogDataService;

        private readonly MainPageViewModel mainPageViewModel;
        private readonly NewEntryPageViewModel newEntryPageViewModel;

        public TripLogIntegrationTests()
        {
            tripLogFactoryMock = new Mock<ITripLogFactory>();
            var httpClient = new StandardAsyncHttpClient();
            tripLogDataService = new RestTripLogDataService(httpClient, new Uri("http://localhost:10080/Api/TripLog"));
            mainPageViewModel = new MainPageViewModel(tripLogFactoryMock.Object, tripLogDataService);

            tripLogNavigationMock = new Mock<ITripLogNavigation>();
            geoLocationServiceMock = new Mock<IGeoLocationService>();
            newEntryPageViewModel = new NewEntryPageViewModel(tripLogNavigationMock.Object, geoLocationServiceMock.Object, tripLogDataService);
        }

        [TestCleanup]
        public async Task ShutDown()
        {
            await Reset();
        }

        [TestMethod]
        public async Task InitMainPage_AfterAddingThreeEntries_ReturnsAllEntries()
        {
            // Arrange
            await Reset();
            newEntryPageViewModel.Title = "Title1";
            newEntryPageViewModel.SaveCommand.Execute(null);
            Thread.Sleep(100);
            newEntryPageViewModel.Title = "Title2";
            newEntryPageViewModel.SaveCommand.Execute(null);
            Thread.Sleep(100);
            newEntryPageViewModel.Title = "Title3";
            newEntryPageViewModel.SaveCommand.Execute(null);
            Thread.Sleep(100);

            // Act
            await mainPageViewModel.Init();
            Thread.Sleep(100);

            // Assert
            var entries = mainPageViewModel.Entries;
            Assert.AreEqual(3, entries.Count);
        }

        [TestMethod]
        public async Task DeleteAllEntries_AfterAddingThreeEntries_AllEntriesDeleted()
        {
            // Arrange
            var entry1 = new TripLogEntry() { Title = "Title1" };
            var entry2 = new TripLogEntry() { Title = "Title2" };
            var entry3 = new TripLogEntry() { Title = "Title3" };

            await Reset();
            newEntryPageViewModel.Title = entry1.Title;
            newEntryPageViewModel.SaveCommand.Execute(null);
            Thread.Sleep(100);
            newEntryPageViewModel.Title = entry2.Title;
            newEntryPageViewModel.SaveCommand.Execute(null);
            Thread.Sleep(100);
            newEntryPageViewModel.Title = entry3.Title;
            newEntryPageViewModel.SaveCommand.Execute(null);
            Thread.Sleep(100);
            mainPageViewModel.DeleteCommand.Execute(entry1);
            Thread.Sleep(100);
            mainPageViewModel.DeleteCommand.Execute(entry2);
            Thread.Sleep(100);
            mainPageViewModel.DeleteCommand.Execute(entry3);
            Thread.Sleep(100);

            // Act
            await mainPageViewModel.Init();
            Thread.Sleep(100);

            // Assert
            var entries = mainPageViewModel.Entries;
            Assert.AreEqual(0, entries.Count);
        }

        private async Task Reset()
        {
            foreach (var entry in await tripLogDataService.ReadAllEntriesAsync())
            {
                await tripLogDataService.DeleteEntryAsync(entry);
            }
        }
    }
}
