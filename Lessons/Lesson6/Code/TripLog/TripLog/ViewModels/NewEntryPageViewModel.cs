using System;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryPageViewModel : ViewModelBase
    {
        private string notes;
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                if(notes != value)
                {
                    notes = value;
                    NotifyPropertyChanged(nameof(Notes));
                }
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    NotifyPropertyChanged(nameof(Title));
                    SaveCommand.ChangeCanExecute();
                }
            }
        }

        private int rating;
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    NotifyPropertyChanged(nameof(Rating));
                }
            }
        }

        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    NotifyPropertyChanged(nameof(Latitude));
                }
            }
        }

        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    NotifyPropertyChanged(nameof(Longitude));
                }
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    NotifyPropertyChanged(nameof(Date));
                }
            }
        }

        private Command saveCommand;
        public Command SaveCommand
        { 
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new Command(
                      SaveProcedure,
                      CanSaveCommandBeExecuted);
                }

                return saveCommand;
            }
            set => saveCommand = value;
        }

        private readonly ITripLogNavigation tripLogNavigation;
        private readonly IGeoLocationService geoLocation;
        private readonly ITripLogDataService tripLogDataService;

        public NewEntryPageViewModel(
            ITripLogNavigation tripLogNavigation,
            IGeoLocationService geoLocation,
            ITripLogDataService tripLogDataService)
        {
            this.tripLogNavigation = tripLogNavigation;
            this.geoLocation = geoLocation;
            this.tripLogDataService = tripLogDataService;
        }

        public async Task Init()
        {
            this.Date = DateTime.Now;
            this.Rating = 1;

            var coordinates = await this.geoLocation.GetCoordinatesAsync();

            this.Latitude = coordinates.Latitude;
            this.Longitude = coordinates.Longitude;
        }

        private async void SaveProcedure()
        {
            var newEntry = new TripLogEntry()
            {
                Title = Title,
                Longitude = Longitude,
                Latitude = Latitude,
                Rating = Rating,
                Notes = Notes,
                Date = Date
            };

            await this.tripLogDataService.AddEntryAsync(newEntry);

            await this.tripLogNavigation.PopAsync();
        }

        private bool CanSaveCommandBeExecuted()
        {
            return !string.IsNullOrEmpty(Title);
        }
    }
}