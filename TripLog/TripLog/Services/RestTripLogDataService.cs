using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public class RestTripLogDataService : TripLogDataService
    {
        protected readonly StandardAsyncHttpClient _httpClient;
        protected readonly Uri _baseUri;
        protected readonly IDictionary<string, string> _headers;

        public RestTripLogDataService(StandardAsyncHttpClient httpClient, Uri baseUri)
        {
            _httpClient = httpClient;
            _baseUri = baseUri;
            _headers = new Dictionary<string, string>();
        }

        public async Task AddEntryAsync(TripLogEntry entry)
        {
            var response = await _httpClient.SendRequestAsync<TripLogEntry>(_baseUri, HttpMethod.Post, _headers, entry);
        }

        public async Task<IList<TripLogEntry>> ReadAllEntriesAsync()
        {
            var response = await _httpClient.SendRequestAsync<TripLogEntry[]>(_baseUri, HttpMethod.Get, _headers);
            return response;
        }
    }
}