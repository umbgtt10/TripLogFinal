namespace TripLog.Test.Acceptance
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TripLog.Models;
    using TripLog.Services;

    [TestClass]
    public class RestTripLogDataServiceTests
    {
        public static TripLogEntry First = new TripLogEntry() { Title = "First"};
        public static TripLogEntry Second = new TripLogEntry() {Title = "Second"};

        private ExtendedRestTripLogDataService _client;
        private Uri _url;

        [TestInitialize]
        public async void Setup()
        {
            _url = new Uri("http://localhost:30080/api/TripLogWebApi/");
            var httpClient = new StandardAsyncHttpClient();
            _client = new ExtendedRestTripLogDataService(httpClient, _url);
            await SetBaseLine();
        }

        [TestCleanup]
        public async Task ShutDown()
        {
            await SetBaseLine();
        }

        private async Task SetBaseLine()
        {
            if (_client != null)
            {
                await _client.RemoveAll();
            }
        }

        [TestMethod]
        public async Task SimpleInsertRetrieveTest()
        {
            await _client.AddEntryAsync(First);

            var retrieved = await _client.ReadAllEntriesAsync();

            Assert.AreEqual(1, retrieved.Count);
            Assert.AreEqual(First, retrieved.First()); // <====  This seems to fail...why?
        }

        [TestMethod]
        public async Task RemoveAllTest()
        {
            await _client.AddEntryAsync(First);
            await _client.AddEntryAsync(Second);
            await _client.RemoveAll();

            var retrieved = await _client.ReadAllEntriesAsync();

            Assert.AreEqual(0, retrieved.Count);
        }
    }
}
