namespace TripLog.Test
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models;
    using ViewModels;

    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task MainViewModelInitializationThrowsTest()
        {
            var viewModel = new MainViewModel(TestInit.MockedTripLogDataService.Object);

            var entry = new TripLogEntry();

            await viewModel.Init(entry);
        }

        [TestMethod]
        public async Task MainViewModelInitializationOkTest()
        {
            var viewModel = new MainViewModel(TestInit.MockedTripLogDataService.Object);

            await viewModel.Init();

            Assert.AreEqual(4, viewModel.LogEntries.Count);
        }

        [TestMethod]
        public async Task DetailViewModelInitializationThrowsTest()
        {
            var viewModel = new DetailViewModel();

            var entry = new TripLogEntry();

            await viewModel.Init(entry);

            Assert.AreEqual(entry, viewModel.Entry);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task DetailViewModelInitializationOkTest()
        {
            var viewModel = new DetailViewModel();

            await viewModel.Init();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task NewEntryViewModelInitializationThrowsTest()
        {
            var viewModel = new NewEntryViewModel(TestInit.MockedGeoLocationService.Object, TestInit.MockedTripLogDataService.Object);

            var entry = new TripLogEntry();

            await viewModel.Init(entry);
        }

        [TestMethod]
        public async Task NewEntryViewModelInitializationOkTest()
        {
            var viewModel = new NewEntryViewModel(TestInit.MockedGeoLocationService.Object, TestInit.MockedTripLogDataService.Object);

            await viewModel.Init();

            Assert.AreEqual(1, viewModel.Rating);
        }
    }
}
