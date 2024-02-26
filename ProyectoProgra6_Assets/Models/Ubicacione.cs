using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class Ubicacione
{
    public int UbicacionId { get; set; }

    public string? UbicacionActual { get; set; }

    public string? HistorialUbicaciones { get; set; }

    public int? NumeroLocal { get; set; }

    public int VehiculoId { get; set; }

    public virtual Vehículo Vehiculo { get; set; } = null!;
}
