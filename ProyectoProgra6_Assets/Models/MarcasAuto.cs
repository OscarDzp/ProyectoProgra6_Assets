using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class MarcasAuto
{
    public int MarcaId { get; set; }

    public string? NombreMarca { get; set; }

    public virtual ICollection<ModelosAuto> ModelosAutos { get; set; } = new List<ModelosAuto>();
}
