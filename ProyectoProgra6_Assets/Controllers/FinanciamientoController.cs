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
    public class FinanciamientoController : ControllerBase
    {
        private readonly Progra6Proyecto2024Context _context;

        public FinanciamientoController(Progra6Proyecto2024Context context)
        {
            _context = context;
        }

        // GET: api/Financiamiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Financiamiento>>> GetFinanciamientos()
        {
            return await _context.Financiamientos.ToListAsync();
        }

        // GET: api/Financiamiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Financiamiento>> GetFinanciamiento(int id)
        {
            var financiamiento = await _context.Financiamientos.FindAsync(id);

            if (financiamiento == null)
            {
                return NotFound();
            }

            return financiamiento;
        }

        // PUT: api/Financiamiento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanciamiento(int id, Financiamiento financiamiento)
        {
            if (id != financiamiento.FinanciamientoId)
            {
                return BadRequest();
            }

            _context.Entry(financiamiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanciamientoExists(id))
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

        // POST: api/Financiamiento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Financiamiento>> PostFinanciamiento(Financiamiento financiamiento)
        {
            _context.Financiamientos.Add(financiamiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinanciamiento", new { id = financiamiento.FinanciamientoId }, financiamiento);
        }

        // DELETE: api/Financiamiento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanciamiento(int id)
        {
            var financiamiento = await _context.Financiamientos.FindAsync(id);
            if (financiamiento == null)
            {
                return NotFound();
            }

            _context.Financiamientos.Remove(financiamiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinanciamientoExists(int id)
        {
            return _context.Financiamientos.Any(e => e.FinanciamientoId == id);
        }
    }
}
