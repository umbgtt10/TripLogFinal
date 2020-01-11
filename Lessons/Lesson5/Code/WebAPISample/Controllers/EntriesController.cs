using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly IList<Entry> entries = new List<Entry>();

        private readonly ILogger<EntriesController> _logger;

        public EntriesController(ILogger<EntriesController> logger)
        {
            _logger = logger;
            this.entries.Add(new Entry() { Id = 5, Message = "First" });
            this.entries.Add(new Entry() { Id = 10, Message = "Second" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entry>> GetElements()
        {
            return Ok(entries);
        }

        [HttpPost]
        public ActionResult<Entry> PostElement(Entry value)
        {
            entries.Add(value);

            return CreatedAtAction(nameof(GetElements), new { id = value.Id }, value);
        }
    }
}
