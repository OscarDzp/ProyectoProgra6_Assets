using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class CategoríasVehículo
{
    public int CategoriaId { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Vehículo> Vehículos { get; set; } = new List<Vehículo>();
}
