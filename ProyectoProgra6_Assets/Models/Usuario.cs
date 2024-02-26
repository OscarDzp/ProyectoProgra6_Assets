using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Cedula { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contrasennia { get; set; }

    public int RolId { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual RolUsuario Rol { get; set; } = null!;
}
