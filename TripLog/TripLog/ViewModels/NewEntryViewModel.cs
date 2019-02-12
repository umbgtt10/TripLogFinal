namespace TripLog.ViewModels
{
    using System;

    using Xamarin.Forms;

    using Models;
    using Services;
    
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

        private readonly GeoLocationService _locationService;
        private readonly TripLogDataService _dataService;

        public NewEntryViewModel(
            GeoLocationService locationService,
            TripLogDataService dataService)
        {
            _locationService = locationService;
            _dataService = dataService;
        }

        public override async void Init()
        {
            Date = DateTime.Now;
            Rating = 1;

            var coordinates = await _locationService.PullCoordinatesAsync();

            Longitude = coordinates.Longitude;
            Latitude = coordinates.Latitude;
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

            _dataService.AddEntryAsync(newEntry);

            // TODO: We should go back to the main screen...
        }
    }
}
