using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacacionesTesisApp.Server.Data;
using VacacionesTesisApp.Shared.Models;

namespace VacacionesTesisApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Estatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estatus>>> GetEstatus()
        {
            return await _context.Estatus.ToListAsync();
        }

        // GET: api/Estatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estatus>> GetEstatus(string id)
        {
            var estatus = await _context.Estatus.FindAsync(id);

            if (estatus == null)
            {
                return NotFound();
            }

            return estatus;
        }

        // PUT: api/Estatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstatus(string id, Estatus estatus)
        {
            if (id != estatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(estatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstatusExists(id))
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

        // POST: api/Estatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Estatus>> PostEstatus(Estatus estatus)
        {
            _context.Estatus.Add(estatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstatusExists(estatus.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstatus", new { id = estatus.Id }, estatus);
        }

        // DELETE: api/Estatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estatus>> DeleteEstatus(string id)
        {
            var estatus = await _context.Estatus.FindAsync(id);
            if (estatus == null)
            {
                return NotFound();
            }

            _context.Estatus.Remove(estatus);
            await _context.SaveChangesAsync();

            return estatus;
        }

        private bool EstatusExists(string id)
        {
            return _context.Estatus.Any(e => e.Id == id);
        }
    }
}
