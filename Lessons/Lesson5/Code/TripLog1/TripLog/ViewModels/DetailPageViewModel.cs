using System;
using System.Windows.Input;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private TripLogEntry entry;
        public TripLogEntry Entry
        {
            get
            {
                return entry;
            }
            set
            {
                if (value != entry)
                {
                    entry = value;
                    NotifyPropertyChanged(nameof(Entry));
                }
            }
        }

        private ICommand backCommand;

        public ICommand BackCommand
        {
            get
            {
                if(backCommand == null)
                {
                    backCommand = new Command(BackProcedure);
                }

                return backCommand;
            }
        }

        private readonly ITripLogNavigation tripLogNavigation;

        public DetailPageViewModel(ITripLogNavigation tripLogNavigation)
        {
            this.tripLogNavigation = tripLogNavigation;
        }

        public void Init(TripLogEntry entry)
        {
            this.Entry = entry;
        }

        private void BackProcedure()
        {
            this.tripLogNavigation.PopAsync();
        }
    }
}