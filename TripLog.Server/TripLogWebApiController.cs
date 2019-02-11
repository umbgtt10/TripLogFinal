using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using TripLog.Models;

namespace TripLog.Server
{
    public class TripLogWebApiController : ApiController
    {
        private readonly DbreezeTripLogPersistency _persistency;

        public TripLogWebApiController()
        {
            _persistency = new DbreezeTripLogPersistency(new DirectoryInfo(@"C:\WebServer\Persistency"));
            _persistency.Setup();
        }

        // GET: api/TripLogApi
        public IEnumerable<TripLogEntry> Get()
        {
            var results = _persistency.GetAll();

            _persistency.Dispose();

            return results;
        }

        // GET: api/TripLogApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TripLogApi
        public void Post([FromBody]TripLogEntry value)
        {
            _persistency.Add(value);

            _persistency.Dispose();
        }

        // PUT: api/TripLogApi/5
        public void Put(int id, [FromBody]TripLogEntry value)
        {
        }

        // DELETE: api/TripLogApi/5
        public void Delete(int id)
        {
        }
    }
}
