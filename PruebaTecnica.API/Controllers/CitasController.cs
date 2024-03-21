using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.API.Models;

namespace PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly aspnetPruebaTecnicaWEBc85c914f80d54c1aab160c2e92b0797bContext _context;

        public CitasController(aspnetPruebaTecnicaWEBc85c914f80d54c1aab160c2e92b0797bContext context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citum>>> GetCitas()
        {
            if (_context.Cita == null)
            {
                return NotFound();
            }
            return await _context.Cita.Include(x => x.Cliente).Include(x => x.Servicio).Select(x => new Citum()
            {
                CitaId = x.CitaId,
                Cliente = new AspNetUser()
                {
                    Name = x.Cliente.Name,
                },
                Servicio = new Servicio()
                {
                    Nombre = x.Servicio.Nombre,
                },
                Fecha = x.Fecha,
                Estado = x.Estado
            }).OrderBy(x => x.Fecha).ToListAsync();
        }

        [HttpGet("Cliente/{id}")]
        public async Task<ActionResult<IEnumerable<Citum>>> GetCitasCliente(string id)
        {
            if (_context.Cita == null)
            {
                return NotFound();
            }
            return await _context.Cita.Include(x => x.Cliente).Include(x => x.Servicio).Where(x => x.ClienteId == id).Select(x => new Citum()
            {
                CitaId = x.CitaId,
                Servicio = new Servicio()
                {
                    Nombre = x.Servicio.Nombre,
                },
                Fecha = x.Fecha,
                Estado = x.Estado
            }).OrderBy(x => x.Fecha).ToListAsync();
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Citum>> GetCita(Guid id)
        {
            if (_context.Cita == null)
            {
                return NotFound();
            }
            var Cita = await _context.Cita.Include(x => x.Cliente).Include(x => x.Servicio).Select(x => new Citum()
            {
                CitaId = x.CitaId,
                Cliente = new AspNetUser()
                {
                    Name = x.Cliente.Name,
                },
                Servicio = new Servicio()
                {
                    Nombre = x.Servicio.Nombre,
                },
                ServicioId = x.ServicioId,
                ClienteId = x.ClienteId,
                Fecha = x.Fecha,
                Estado = x.Estado
            }).FirstOrDefaultAsync(x => x.CitaId == id);

            if (Cita == null)
            {
                return NotFound();
            }

            return Cita;
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(Guid id, Citum cita)
        {
            if (id != cita.CitaId)
            {
                return BadRequest();
            }

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(id))
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

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Citum>> PostCita(Citum cita)
        {
            if (_context.Cita == null)
            {
                return Problem("Entity set 'aspnetPruebaTecnicaWEBc85c914f80d54c1aab160c2e92b0797bContext.Cita'  is null.");
            }
            _context.Cita.Add(cita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CitaExists(cita.CitaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCita", new { id = cita.CitaId }, cita);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(Guid id)
        {
            if (_context.Cita == null)
            {
                return NotFound();
            }
            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitaExists(Guid id)
        {
            return (_context.Cita?.Any(e => e.CitaId == id)).GetValueOrDefault();
        }
    }
}
