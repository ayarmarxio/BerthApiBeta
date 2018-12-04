using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BerthApiBeta.Models;

namespace BerthApiBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaspberryRecordsController : ControllerBase
    {
        private readonly BerthApiBetaContext _context;

        public RaspberryRecordsController(BerthApiBetaContext context)
        {
            _context = context;
        }

        // GET: api/RaspberryRecords
        [HttpGet]
        public IEnumerable<RaspberryRecord> GetRaspberryRecord()
        {
            return _context.RaspberryRecord;
        }

        // GET: api/RaspberryRecords/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRaspberryRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var raspberryRecord = await _context.RaspberryRecord.FindAsync(id);

            if (raspberryRecord == null)
            {
                return NotFound();
            }

            return Ok(raspberryRecord);
        }

        // PUT: api/RaspberryRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaspberryRecord([FromRoute] int id, [FromBody] RaspberryRecord raspberryRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raspberryRecord.RecordId)
            {
                return BadRequest();
            }

            _context.Entry(raspberryRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaspberryRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RaspberryRecords
        [HttpPost]
        public async Task<IActionResult> PostRaspberryRecord([FromBody] RaspberryRecord raspberryRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RaspberryRecord.Add(raspberryRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction($"GetRaspberryRecord", new { id = raspberryRecord.RecordId }, raspberryRecord);
        }

        // DELETE: api/RaspberryRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaspberryRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var raspberryRecord = await _context.RaspberryRecord.FindAsync(id);
            if (raspberryRecord == null)
            {
                return NotFound();
            }

            _context.RaspberryRecord.Remove(raspberryRecord);
            await _context.SaveChangesAsync();

            return Ok(raspberryRecord);
        }

        private bool RaspberryRecordExists(int id)
        {
            return _context.RaspberryRecord.Any(e => e.RecordId == id);
        }
    }
}