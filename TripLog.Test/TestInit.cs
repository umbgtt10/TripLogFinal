namespace TripLog.Test
{
    using System.Collections.Generic;

    using Moq;

    using Models;
    using Services;
    using ViewModels;

    public class TestInit
    {
        public static Mock<GeoLocationService> MockedGeoLocationService = new Mock<GeoLocationService>();
        public static Mock<TripLogDataService> MockedTripLogDataService = new Mock<TripLogDataService>();
        public static ViewModelFactory ViewModelFactory;
        public static GeoCoords FakeCoordinates;
        public static IList<TripLogEntry> FakeTripLogEntryCollection;

        static TestInit()
        {
            FakeCoordinates = new GeoCoords {Latitude = 123, Longitude = 321};
            FakeTripLogEntryCollection = new List<TripLogEntry>() { new TripLogEntry() };

            MockedGeoLocationService.Setup(query => query.PullCoordinatesAsync()).
                ReturnsAsync(FakeCoordinates);

            MockedTripLogDataService.Setup(query => query.AddEntryAsync(new TripLogEntry()));
            MockedTripLogDataService.Setup(query => query.ReadAllEntriesAsync()).
                ReturnsAsync(FakeTripLogEntryCollection);

            ViewModelFactory = new ViewModelFactory(MockedGeoLocationService.Object, MockedTripLogDataService.Object);
        }
    }
}
