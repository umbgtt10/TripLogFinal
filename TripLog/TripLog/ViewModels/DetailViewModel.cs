namespace TripLog.ViewModels
{
    using System;

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

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void Init(TripLogEntry entry)
        {
            Entry = entry;
        }
    }
}
