using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra6_Assets.Attributes;
using ProyectoProgra6_Assets.Models;

namespace ProyectoProgra6_Assets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class CategoríasVehículoController : ControllerBase
    {
        private readonly Progra6Proyecto2024Context _context;

        public CategoríasVehículoController(Progra6Proyecto2024Context context)
        {
            _context = context;
        }

        // GET: api/CategoríasVehículo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoríasVehículo>>> GetCategoríasVehículos()
        {
            return await _context.CategoríasVehículos.ToListAsync();
        }

        // GET: api/CategoríasVehículo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoríasVehículo>> GetCategoríasVehículo(int id)
        {
            var categoríasVehículo = await _context.CategoríasVehículos.FindAsync(id);

            if (categoríasVehículo == null)
            {
                return NotFound();
            }

            return categoríasVehículo;
        }

        // PUT: api/CategoríasVehículo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoríasVehículo(int id, CategoríasVehículo categoríasVehículo)
        {
            if (id != categoríasVehículo.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoríasVehículo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoríasVehículoExists(id))
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

        // POST: api/CategoríasVehículo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoríasVehículo>> PostCategoríasVehículo(CategoríasVehículo categoríasVehículo)
        {
            _context.CategoríasVehículos.Add(categoríasVehículo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoríasVehículo", new { id = categoríasVehículo.CategoriaId }, categoríasVehículo);
        }

        // DELETE: api/CategoríasVehículo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoríasVehículo(int id)
        {
            var categoríasVehículo = await _context.CategoríasVehículos.FindAsync(id);
            if (categoríasVehículo == null)
            {
                return NotFound();
            }

            _context.CategoríasVehículos.Remove(categoríasVehículo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoríasVehículoExists(int id)
        {
            return _context.CategoríasVehículos.Any(e => e.CategoriaId == id);
        }
    }
}
