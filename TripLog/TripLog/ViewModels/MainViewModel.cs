﻿namespace TripLog.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;
    using Services;

    public class MainViewModel : BaseViewModel
    {
        #region Observables

        private ObservableCollection<TripLogEntry> _logEntries;
        public ObservableCollection<TripLogEntry> LogEntries
        {
            get
            {
                return _logEntries;
            }

            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private readonly TripLogDataService _dataService;

        public MainViewModel(TripLogDataService dataService)
        {
            _dataService = dataService;
        }

        public override async Task Init()
        {
            LogEntries = new ObservableCollection<TripLogEntry>(await RetrieveEntries());
        }

        public override Task Init(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }

        private async Task<IList<TripLogEntry>> RetrieveEntries()
        {
            var data = await _dataService.ReadAllEntriesAsync();
            var hardCodedData = new List<TripLogEntry>
            {
                new TripLogEntry
                {
                    Title = "Washington Monument",
                    Notes = "Amazing!",
                    Rating = 3,
                    Date = new DateTime(2017, 2, 5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                },
                new TripLogEntry
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring!",
                    Rating = 4,
                    Date = new DateTime(2017, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },
                new TripLogEntry
                {
                    Title = "Golden Gate Bridge",
                    Notes = "Foggy, but beautiful.",
                    Rating = 5,
                    Date = new DateTime(2017, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
            };

            return new List<TripLogEntry>(data).Union(hardCodedData).ToList();
        }        
    }
}
