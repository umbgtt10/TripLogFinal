using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Views
{
    public class TripLogFactory : ITripLogFactory
    {
        private readonly ViewModelFactory viewModelFactory;
        private readonly ViewFactory viewFactory;
        private readonly ITripLogNavigation navigation;

        public TripLogFactory(
            ViewFactory viewFactory,
            ViewModelFactory viewModelFactory,
            ITripLogNavigation navigation)
        {
            this.viewFactory = viewFactory;
            this.viewModelFactory = viewModelFactory;
            this.navigation = navigation;
        }

        public Task NavigateToNewPage()
        {
            var vm = this.viewModelFactory.BuildNewEntryPageViewModel();
            var page = this.viewFactory.BuildNewPage(vm);
            vm.Init();
            return navigation.PushAsync(page);
        }

        public Task NavigateToDetailPage(TripLogEntry entry)
        {
            var vm = this.viewModelFactory.BuildDetailPageViewModel();
            vm.Init(entry);
            var page = this.viewFactory.BuildDetailPage(vm);
            return navigation.PushAsync(page);
        }
    }
}
