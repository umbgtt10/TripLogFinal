using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TripLog.Server
{
    public class TripLogWebApiController : ApiController
    {
        // GET: api/TripLogApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TripLogApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TripLogApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TripLogApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TripLogApi/5
        public void Delete(int id)
        {
        }
    }
}
