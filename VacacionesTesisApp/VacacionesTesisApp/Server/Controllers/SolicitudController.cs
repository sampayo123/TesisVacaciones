using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using VacacionesTesisApp.Server.Data;
using VacacionesTesisApp.Shared.Models;

namespace VacacionesTesisApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SolicitudController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Solicitud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicituds()
        {
            return await _context.Solicituds.Include(x => x.Empleado).ToListAsync();
        }

        // GET: api/Solicitud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(string id)
        {
            var solicitud = await _context.Solicituds.Include(x => x.Empleado).Where(x => x.EmpleadoId ==id).ToListAsync();

            if (solicitud == null)
            {
                return NotFound();
            }

            return Ok(solicitud);
        }

        
        [HttpGet("SolicitudPermiso/{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitudPermisos(string id)
        {
            var solicitud = await _context.Solicituds.Include(x => x.Empleado).Where(x => x.EmpleadoId == id && x.Tipo == "Permiso").ToListAsync();

            if (solicitud == null)
            {
                return NotFound();
            }

            return Ok(solicitud);
        }


        [HttpGet("SolicitudVacaciones/{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitudVacaciones(string id)
        {
            var solicitud = await _context.Solicituds.Include(x => x.Empleado).Where(x => x.EmpleadoId == id && x.Tipo == "Vacaciones").ToListAsync();

            if (solicitud == null)
            {
                return NotFound();
            }

            return Ok(solicitud);
        }





        // PUT: api/Solicitud/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPut]
        public async Task<IActionResult> PutSolicitud(Solicitud solicitud)
        {
            _context.Entry(solicitud).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(solicitud);
        }
       

        // POST: api/Solicitud
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(Solicitud solicitud)
        {
            var guid = Guid.NewGuid();
            solicitud.Id = guid.ToString();
            _context.Solicituds.Add(solicitud);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SolicitudExists(solicitud.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(solicitud.Id);
        }

        // DELETE: api/Solicitud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Solicitud>> DeleteSolicitud(string id)
        {
            var solicitud = await _context.Solicituds.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            _context.Solicituds.Remove(solicitud);
            await _context.SaveChangesAsync();

            return solicitud;
        }

        private bool SolicitudExists(string id)
        {
            return _context.Solicituds.Any(e => e.Id == id);
        }
    }
}
