using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class Financiamiento
{
    public int FinanciamientoId { get; set; }

    public string? TipoFinanciamiento { get; set; }

    public string? Plazo { get; set; }

    public string? TasaInteres { get; set; }

    public string? CuotaMensual { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
