using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TripLog.Models;

namespace TripLog.Server
{
    public class TripLogWebApiController : ApiController
    {
        // GET: api/TripLogApi
        public IEnumerable<TripLogEntry> Get()
        {
            return new TripLogEntry[] { new TripLogEntry(), new TripLogEntry() };
        }

        // GET: api/TripLogApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TripLogApi
        public void Post([FromBody]TripLogEntry value)
        {
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
