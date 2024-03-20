using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra6_Assets.Attributes;
using ProyectoProgra6_Assets.Models;
using ProyectoProgra6_Assets.ModelsDTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ProyectoProgra6_Assets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [ApiKey]
    public class UsuariosController : ControllerBase
    {
        private readonly Progra6Proyecto2024Context _context;

        public UsuariosController(Progra6Proyecto2024Context context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpGet("GetUserData")]
        public ActionResult<IEnumerable<UsuarioDTO>> GetUserData(string pCorreo_electronico)
        {
            var query = (from us in _context.Usuarios
                         join ur in _context.RolUsuarios on us.RolId equals ur.RolId
                         where us.CorreoElectronico == pCorreo_electronico
                         select new
                         {
                             UsuarioId = us.UsuarioId,
                             Nombre = us.Nombre,
                             Apellido = us.Apellido,
                             Cedula = us.Cedula,
                             Telefono = us.Telefono,
                             CorreoElectronico = us.CorreoElectronico,
                             Contrasennia = us.Contrasennia,
                             RolId = ur.RolId,
                             RolUsuario = ur.RolUsuario1
                         }).ToList();

            List<UsuarioDTO> listausuarios = new List<UsuarioDTO>();

            foreach (var item in query)
            {
                UsuarioDTO newusuario = new UsuarioDTO
                {
                    UsuarioId = item.UsuarioId,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Cedula = item.Cedula,
                    Telefono = item.Telefono,
                    CorreoElectronico = item.CorreoElectronico,
                    Contrasennia = item.Contrasennia,
                    RolId = item.RolId,
                    RolUsuario = item.RolUsuario
                };
                listausuarios.Add(newusuario);
            }

            if (listausuarios == null || listausuarios.Count == 0)
            {
                return NotFound();
            }

            return listausuarios;
        }








        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
