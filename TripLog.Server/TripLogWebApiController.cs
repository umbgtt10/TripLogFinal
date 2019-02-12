namespace TripLog.Server
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Models;

    public class TripLogWebApiController : ApiController
    {
        private readonly TripLogPersistency _persistency;
        private readonly Environment _environment;

        public TripLogWebApiController()
        {
            _environment = Environment.Test;
            _persistency = new TripLogPersistencyBuilder(new DirectoryInfo(@"C:\WebServer\Persistency")).
                Build(_environment);
            _persistency.Setup();
        }

        // GET: api/TripLogApi
        [ResponseType(typeof(IEnumerable<TripLogEntry>))]
        public IHttpActionResult Get()
        {
            try
            {
                var results = _persistency.GetAll();
                _persistency.Dispose();

                return Ok(results);
            }
            catch (Exception e)
            {
                return ThrowHttpResponseException(e);
            }
        }

        // GET: api/TripLogApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Get(int id)
        {
            throw new HttpResponseException(HttpStatusCode.NotAcceptable);
        }

        // POST: api/TripLogApi
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody] TripLogEntry value)
        {
            try
            {
                _persistency.Add(value);
                _persistency.Dispose();

                return CreatedAtRoute("DefaultApi", new {id = value.Id}, value);
            }
            catch (Exception e)
            {
                return ThrowHttpResponseException(e);
            }
        }

        // PUT: api/TripLogApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]TripLogEntry value)
        {
            throw new HttpResponseException(HttpStatusCode.NotAcceptable);
        }

        // DELETE: api/TripLogApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (_environment == Environment.Test)
                {
                    ((ExtendedDbreezeTripLogPersistency) _persistency).RemoveAll();
                    _persistency.Dispose();

                    return Ok();
                }

                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }
            catch (Exception e)
            {
                return ThrowHttpResponseException(e);
            }
        }

        private IHttpActionResult ThrowHttpResponseException(Exception e)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                ReasonPhrase = e.Message
            };

            throw new HttpResponseException(responseMessage);
        }
    }
}
