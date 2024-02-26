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
    public class MarcasAutoController : ControllerBase
    {
        private readonly Progra6Proyecto2024Context _context;

        public MarcasAutoController(Progra6Proyecto2024Context context)
        {
            _context = context;
        }

        // GET: api/MarcasAuto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcasAuto>>> GetMarcasAutos()
        {
            return await _context.MarcasAutos.ToListAsync();
        }

        // GET: api/MarcasAuto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcasAuto>> GetMarcasAuto(int id)
        {
            var marcasAuto = await _context.MarcasAutos.FindAsync(id);

            if (marcasAuto == null)
            {
                return NotFound();
            }

            return marcasAuto;
        }

        // PUT: api/MarcasAuto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarcasAuto(int id, MarcasAuto marcasAuto)
        {
            if (id != marcasAuto.MarcaId)
            {
                return BadRequest();
            }

            _context.Entry(marcasAuto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcasAutoExists(id))
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

        // POST: api/MarcasAuto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MarcasAuto>> PostMarcasAuto(MarcasAuto marcasAuto)
        {
            _context.MarcasAutos.Add(marcasAuto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarcasAuto", new { id = marcasAuto.MarcaId }, marcasAuto);
        }

        // DELETE: api/MarcasAuto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarcasAuto(int id)
        {
            var marcasAuto = await _context.MarcasAutos.FindAsync(id);
            if (marcasAuto == null)
            {
                return NotFound();
            }

            _context.MarcasAutos.Remove(marcasAuto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarcasAutoExists(int id)
        {
            return _context.MarcasAutos.Any(e => e.MarcaId == id);
        }
    }
}
