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
    public class ModelosAutoController : ControllerBase
    {
        private readonly Progra6Proyecto2024Context _context;

        public ModelosAutoController(Progra6Proyecto2024Context context)
        {
            _context = context;
        }

        // GET: api/ModelosAuto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelosAuto>>> GetModelosAutos()
        {
            return await _context.ModelosAutos.ToListAsync();
        }

        // GET: api/ModelosAuto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelosAuto>> GetModelosAuto(int id)
        {
            var modelosAuto = await _context.ModelosAutos.FindAsync(id);

            if (modelosAuto == null)
            {
                return NotFound();
            }

            return modelosAuto;
        }

        // PUT: api/ModelosAuto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelosAuto(int id, ModelosAuto modelosAuto)
        {
            if (id != modelosAuto.ModeloId)
            {
                return BadRequest();
            }

            _context.Entry(modelosAuto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelosAutoExists(id))
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

        // POST: api/ModelosAuto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelosAuto>> PostModelosAuto(ModelosAuto modelosAuto)
        {
            _context.ModelosAutos.Add(modelosAuto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelosAuto", new { id = modelosAuto.ModeloId }, modelosAuto);
        }

        // DELETE: api/ModelosAuto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelosAuto(int id)
        {
            var modelosAuto = await _context.ModelosAutos.FindAsync(id);
            if (modelosAuto == null)
            {
                return NotFound();
            }

            _context.ModelosAutos.Remove(modelosAuto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelosAutoExists(int id)
        {
            return _context.ModelosAutos.Any(e => e.ModeloId == id);
        }
    }
}
