using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class Seguro
{
    public int SeguroId { get; set; }

    public string? CompaniaSeguros { get; set; }

    public string? TipoCobertura { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public virtual ICollection<Vehículo> Vehículos { get; set; } = new List<Vehículo>();
}
