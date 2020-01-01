using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TripLog.Models;
using TripLog.Persistency;

namespace TripLog.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripLogController : ControllerBase
    {
        private readonly ILogger<TripLogController> _logger;
        private readonly ITripLogPersistency _persistency;

        public TripLogController(ILogger<TripLogController> logger, ITripLogPersistency persistency)
        {
            _logger = logger;
            _persistency = persistency;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TripLogEntry>> Get()
        {
            try
            {
                return Ok(_persistency.Retrieve());
            }
            catch (Exception e)
            {
                return StatusCode(500, e?.Message);
            }
        }

        [HttpPost]
        public ActionResult<TripLogEntry> Post(TripLogEntry entry)
        {
            try
            {
                _persistency.Store(entry);

                return CreatedAtAction(nameof(Post), new { id = entry.Title }, entry);
            }
            catch (Exception e)
            {
                return StatusCode(500, e?.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(TripLogEntry entry)
        {
            try
            {
                if(_persistency.Delete(entry))
                {
                    return Ok(entry);
                }

                return NotFound(entry);
            }
            catch (Exception e)
            {
                return StatusCode(500, e?.Message);
            }
        }
    }
}
