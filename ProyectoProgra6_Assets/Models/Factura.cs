using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public int? NumeroFactura { get; set; }

    public DateOnly? FechaVenta { get; set; }

    public decimal? MontoTotal { get; set; }

    public int VehiculoId { get; set; }

    public int ClienteId { get; set; }

    public int UsuarioId { get; set; }

    public int FinanciamientoId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Financiamiento Financiamiento { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Vehículo Vehiculo { get; set; } = null!;
}
