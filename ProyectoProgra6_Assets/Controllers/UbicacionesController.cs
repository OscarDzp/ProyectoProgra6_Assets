using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra6_Assets.Models;

namespace ProyectoProgra6_Assets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly Progra6Proyecto2024Context _context;

        public UbicacionesController(Progra6Proyecto2024Context context)
        {
            _context = context;
        }

        // GET: api/Ubicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacione>>> GetUbicaciones()
        {
            return await _context.Ubicaciones.ToListAsync();
        }

        // GET: api/Ubicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacione>> GetUbicacione(int id)
        {
            var ubicacione = await _context.Ubicaciones.FindAsync(id);

            if (ubicacione == null)
            {
                return NotFound();
            }

            return ubicacione;
        }

        // PUT: api/Ubicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacione(int id, Ubicacione ubicacione)
        {
            if (id != ubicacione.UbicacionId)
            {
                return BadRequest();
            }

            _context.Entry(ubicacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacioneExists(id))
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

        // POST: api/Ubicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ubicacione>> PostUbicacione(Ubicacione ubicacione)
        {
            _context.Ubicaciones.Add(ubicacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacione", new { id = ubicacione.UbicacionId }, ubicacione);
        }

        // DELETE: api/Ubicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacione(int id)
        {
            var ubicacione = await _context.Ubicaciones.FindAsync(id);
            if (ubicacione == null)
            {
                return NotFound();
            }

            _context.Ubicaciones.Remove(ubicacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UbicacioneExists(int id)
        {
            return _context.Ubicaciones.Any(e => e.UbicacionId == id);
        }
    }
}
