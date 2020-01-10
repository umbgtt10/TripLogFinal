using System;
using System.Collections.Generic;
using System.IO;
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

        public TripLogController(ILogger<TripLogController> logger)
        {
            _logger = logger;
            _persistency = new TripLogFlatFilePersistency(new FileInfo(@"D:\Temp\persistency.prs"));
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
    }
}
