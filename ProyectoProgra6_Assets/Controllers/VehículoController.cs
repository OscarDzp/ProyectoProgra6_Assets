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
    public class VehículoController : ControllerBase
    {
        private readonly Progra6Proyecto2024Context _context;

        public VehículoController(Progra6Proyecto2024Context context)
        {
            _context = context;
        }

        // GET: api/Vehículo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehículo>>> GetVehículos()
        {
            return await _context.Vehículos.ToListAsync();
        }

        // GET: api/Vehículo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehículo>> GetVehículo(int id)
        {
            var vehículo = await _context.Vehículos.FindAsync(id);

            if (vehículo == null)
            {
                return NotFound();
            }

            return vehículo;
        }

        // PUT: api/Vehículo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehículo(int id, Vehículo vehículo)
        {
            if (id != vehículo.VehiculoId)
            {
                return BadRequest();
            }

            _context.Entry(vehículo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehículoExists(id))
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

        // POST: api/Vehículo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehículo>> PostVehículo(Vehículo vehículo)
        {
            _context.Vehículos.Add(vehículo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehículo", new { id = vehículo.VehiculoId }, vehículo);
        }

        // DELETE: api/Vehículo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehículo(int id)
        {
            var vehículo = await _context.Vehículos.FindAsync(id);
            if (vehículo == null)
            {
                return NotFound();
            }

            _context.Vehículos.Remove(vehículo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehículoExists(int id)
        {
            return _context.Vehículos.Any(e => e.VehiculoId == id);
        }
    }
}
