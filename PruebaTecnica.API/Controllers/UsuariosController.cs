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
    public class UsuariosController : ControllerBase
    {
        private readonly aspnetPruebaTecnicaWEBc85c914f80d54c1aab160c2e92b0797bContext _context;

        public UsuariosController(aspnetPruebaTecnicaWEBc85c914f80d54c1aab160c2e92b0797bContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetUsuarios()
        {
            if (_context.AspNetUsers == null)
            {
                return NotFound();
            }
            return await _context.AspNetUsers.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUser>> GetAspNetUser(string id)
        {
            if (_context.AspNetUsers == null)
            {
                return NotFound();
            }
            var usuario = await _context.AspNetUsers.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
    }
}
