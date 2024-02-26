using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class RolUsuario
{
    public int RolId { get; set; }

    public string? RolUsuario1 { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
