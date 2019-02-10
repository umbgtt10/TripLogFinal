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
            var viewModel = TestInit.ViewModelFactory.Build(ViewType.Main);

            Assert.IsInstanceOfType(viewModel, typeof(MainViewModel));
        }

        [TestMethod]
        public void NewEntryViewModelCreationTest()
        {
            var viewModel = TestInit.ViewModelFactory.Build(ViewType.New);

            Assert.IsInstanceOfType(viewModel, typeof(NewEntryViewModel));
        }

        [TestMethod]
        public void DetailViewModelCreationTest()
        {
            var viewModel = TestInit.ViewModelFactory.Build(ViewType.Detail);

            Assert.IsInstanceOfType(viewModel, typeof(DetailViewModel));
        }
    }
}
