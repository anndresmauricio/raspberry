using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaspberryAPIConnection.Data;
using RaspberryAPIConnection.Models;

namespace RaspberryAPIConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIHumoesController : ControllerBase
    {
        private readonly RaspberryAPIConnectionContext _context;

        public APIHumoesController(RaspberryAPIConnectionContext context)
        {
            _context = context;
        }

        // GET: api/APIHumoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APIHumo>>> GetAPIHumo()
        {
          if (_context.APIHumo == null)
          {
              return NotFound();
          }
            return await _context.APIHumo.ToListAsync();
        }

        // GET: api/APIHumoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APIHumo>> GetAPIHumo(int id)
        {
          if (_context.APIHumo == null)
          {
              return NotFound();
          }
            var aPIHumo = await _context.APIHumo.FindAsync(id);

            if (aPIHumo == null)
            {
                return NotFound();
            }

            return aPIHumo;
        }

        // PUT: api/APIHumoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPIHumo(int id, APIHumo aPIHumo)
        {
            if (id != aPIHumo.Id)
            {
                return BadRequest();
            }

            _context.Entry(aPIHumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIHumoExists(id))
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

        // POST: api/APIHumoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<APIHumo>> PostAPIHumo(APIHumo aPIHumo)
        {
          if (_context.APIHumo == null)
          {
              return Problem("Entity set 'RaspberryAPIConnectionContext.APIHumo'  is null.");
          }
            _context.APIHumo.Add(aPIHumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAPIHumo", new { id = aPIHumo.Id }, aPIHumo);
        }

        // DELETE: api/APIHumoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPIHumo(int id)
        {
            if (_context.APIHumo == null)
            {
                return NotFound();
            }
            var aPIHumo = await _context.APIHumo.FindAsync(id);
            if (aPIHumo == null)
            {
                return NotFound();
            }

            _context.APIHumo.Remove(aPIHumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APIHumoExists(int id)
        {
            return (_context.APIHumo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
