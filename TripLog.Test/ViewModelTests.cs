namespace TripLog.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models;
    using ViewModels;

    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void MainViewModelInitializationThrowsTest()
        {
            var viewModel = new MainViewModel(TestInit.MockedTripLogDataService.Object);

            var entry = new TripLogEntry();

            viewModel.Init(entry);
        }

        [TestMethod]
        public void MainViewModelInitializationOkTest()
        {
            var viewModel = new MainViewModel(TestInit.MockedTripLogDataService.Object);

            viewModel.Init();

            Assert.AreEqual(4, viewModel.LogEntries.Count);
        }

        [TestMethod]
        public void DetailViewModelInitializationThrowsTest()
        {
            var viewModel = new DetailViewModel();

            var entry = new TripLogEntry();

            viewModel.Init(entry);

            Assert.AreEqual(entry, viewModel.Entry);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DetailViewModelInitializationOkTest()
        {
            var viewModel = new DetailViewModel();

            viewModel.Init();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void NewEntryViewModelInitializationThrowsTest()
        {
            var viewModel = new NewEntryViewModel(TestInit.MockedGeoLocationService.Object, TestInit.MockedTripLogDataService.Object);

            var entry = new TripLogEntry();

            viewModel.Init(entry);
        }

        [TestMethod]
        public void NewEntryViewModelInitializationOkTest()
        {
            var viewModel = new NewEntryViewModel(TestInit.MockedGeoLocationService.Object, TestInit.MockedTripLogDataService.Object);

            viewModel.Init();

            Assert.AreEqual(1, viewModel.Rating);
        }
    }
}
