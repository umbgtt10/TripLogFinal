using System;
using System.Net.Http;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.Test.Acceptance
{
    public class ExtendedRestTripLogDataService : RestTripLogDataService
    {
        public ExtendedRestTripLogDataService(StandardAsyncHttpClient httpClient, Uri baseUri)
            : base(httpClient, baseUri)
        { }

        public async Task RemoveAll()
        {
            var response = await _httpClient.SendRequestAsync<TripLogEntry>(_baseUri, HttpMethod.Delete, _headers);
        }
    }
}