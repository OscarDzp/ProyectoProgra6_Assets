using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class Mantenimiento
{
    public int MantenimientoId { get; set; }

    public string? DescripcionMantenimiento { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFinalización { get; set; }

    public decimal? Costo { get; set; }

    public int VehiculoId { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Vehículo Vehiculo { get; set; } = null!;
}
