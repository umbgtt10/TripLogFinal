using System;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        #region Observables

        private TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get { return _entry; }
            set { _entry = value; OnPropertyChanged(); }
        }

        #endregion

        public DetailViewModel(TripLogEntry entry)
        {
            Entry = entry;
        }
    }
}
