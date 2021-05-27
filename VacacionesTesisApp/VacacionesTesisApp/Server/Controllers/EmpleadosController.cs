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
    public class EmpleadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.Include(x => x.Cargo).ToListAsync();
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(string id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutEmpleado(Empleado empleado)
        {
/*            if (id != empleado.Id)
            {
                return BadRequest();
            }*/

            _context.Entry(empleado).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            


            return Ok(empleado.Id);
        }

        // POST: api/Empleados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
                  var guid = Guid.NewGuid();
                empleado.Id = guid.ToString();
            _context.Empleados.Add(empleado);
            try
            {
          

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpleadoExists(empleado.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(empleado);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(string id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(string id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
