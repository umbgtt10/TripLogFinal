using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripLog.ViewModels;

namespace TripLog.Test
{
    [TestClass]
    public class ViewModelFactoryTests
    {
        public static ViewModelFactory ViewModelFactory = new ViewModelFactory(TestInit.MockedGeoLocationService.Object);

        [TestMethod]
        public void MainViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(ViewType.Main);

            Assert.IsInstanceOfType(viewModel, typeof(MainViewModel));
        }

        [TestMethod]
        public void NewEntryViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(ViewType.New);

            Assert.IsInstanceOfType(viewModel, typeof(NewEntryViewModel));
        }

        [TestMethod]
        public void DetailViewModelCreationTest()
        {
            var viewModel = ViewModelFactory.Build(ViewType.Detail);

            Assert.IsInstanceOfType(viewModel, typeof(DetailViewModel));
        }
    }
}
