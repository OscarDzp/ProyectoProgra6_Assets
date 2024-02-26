using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class ModelosAuto
{
    public int ModeloId { get; set; }

    public string? NombreModelo { get; set; }

    public int MarcaId { get; set; }

    public virtual MarcasAuto Marca { get; set; } = null!;

    public virtual ICollection<Vehículo> Vehículos { get; set; } = new List<Vehículo>();
}
