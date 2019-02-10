using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripLog.ViewModels;

namespace TripLog.Test
{
    [TestClass]
    public class ViewModelFactoryTests
    {
        [TestMethod]
        public void MainViewModelCreationTest()
        {
            var viewModelFactory = new ViewModelFactory();

            var viewModel = viewModelFactory.Build(TripLogViewModelType.Main);

            Assert.IsInstanceOfType(viewModel, typeof(MainViewModel));
        }

        [TestMethod]
        public void NewEntryViewModelCreationTest()
        {
            var viewModelFactory = new ViewModelFactory();

            var viewModel = viewModelFactory.Build(TripLogViewModelType.New);

            Assert.IsInstanceOfType(viewModel, typeof(NewEntryViewModel));
        }

        [TestMethod]
        public void DetailViewModelCreationTest()
        {
            var viewModelFactory = new ViewModelFactory();

            var viewModel = viewModelFactory.Build(TripLogViewModelType.Detail);

            Assert.IsInstanceOfType(viewModel, typeof(DetailViewModel));
        }
    }
}
