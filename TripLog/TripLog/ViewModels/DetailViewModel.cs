namespace TripLog.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using Models;

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

        public override Task Init()
        {
            throw new NotImplementedException();
        }

        public override Task Init(TripLogEntry entry)
        {
            Entry = entry;

            return Task.CompletedTask;
        }
    }
}
