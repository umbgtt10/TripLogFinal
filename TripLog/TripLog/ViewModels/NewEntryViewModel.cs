using System;
using TripLog.Models;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseViewModel
    {
        #region Observables

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; OnPropertyChanged(); }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; OnPropertyChanged(); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }

        private int _rating;
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; OnPropertyChanged(); }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands
        private Command _saveCommand;
        public Command SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(
                    ExecuteSaveCommand,
                    () => !string.IsNullOrEmpty(Title));
                }

                return _saveCommand;
            }
            set => _saveCommand = value;
        }

        #endregion

        public NewEntryViewModel()
        {
            Date = DateTime.Now;
            Rating = 1;
        }

        public override void Init()
        {
            Date = DateTime.Now;
            Rating = 1;
        }

        public override void Init(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }

        private void ExecuteSaveCommand()
        {
            var newEntry = new TripLogEntry()
            {
                Title = Title,
                Date = Date,
                Latitude = Latitude,
                Longitude = Longitude,
                Notes = Notes,
                Rating = Rating
            };

            // Persist the newly created entry here!
        }
    }
}
