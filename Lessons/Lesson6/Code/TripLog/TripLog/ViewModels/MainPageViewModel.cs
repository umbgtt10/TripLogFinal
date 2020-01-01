using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TripLog.Models;
using TripLog.Services;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<TripLogEntry> entries;

        public ObservableCollection<TripLogEntry> Entries
        {
            get
            {
                return entries;
            }
            set
            {
                if (entries != value)
                {
                    entries = value;
                    NotifyPropertyChanged(nameof(Entries));
                }
            }
        }

        private ICommand newCommand;

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new Command(NewProcedure);
                }

                return newCommand;
            }
        }

        private ICommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new Command<TripLogEntry>(DeleteProcedure);
                }

                return deleteCommand;
            }
        }

        private TripLogEntry detailSelectItem;

        public TripLogEntry DetailSelectedItem
        {
            get
            {
                return detailSelectItem;
            }
            set
            {
                if (detailSelectItem != value)
                {
                    detailSelectItem = value;
                    DetailProcedure(detailSelectItem);
                    detailSelectItem = null;
                }
            }
        }

        private readonly ITripLogFactory factory;
        private readonly ITripLogDataService tripLogDataService;

        public MainPageViewModel(ITripLogFactory factory, ITripLogDataService tripLogDataService)
        {
            this.factory = factory;
            this.tripLogDataService = tripLogDataService;
            Entries = new ObservableCollection<TripLogEntry>();
        }

        private void NewProcedure()
        {
            this.factory.NavigateToNewPage();
        }

        private async void DeleteProcedure(TripLogEntry entry)
        {
            await this.tripLogDataService.DeleteEntryAsync(entry);

            Entries.Remove(entry);
        }

        private void DetailProcedure(TripLogEntry entry)
        {
            this.factory.NavigateToDetailPage(entry);
        }

        public async Task Init()
        {
            var entries = await this.tripLogDataService.ReadAllEntriesAsync();

            Entries = new ObservableCollection<TripLogEntry>(entries);
        }
    }
}
