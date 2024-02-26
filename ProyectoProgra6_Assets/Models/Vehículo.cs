using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class Vehículo
{
    public int VehiculoId { get; set; }

    public string? Modelo { get; set; }

    public int? Year { get; set; }

    public string? Color { get; set; }

    public decimal? Precio { get; set; }

    public string? Tipo { get; set; }

    public string? Estado { get; set; }

    public DateOnly? FechaIngresoInventario { get; set; }

    public string Placa { get; set; } = null!;

    public int CategoriaId { get; set; }

    public int ModeloId { get; set; }

    public int SeguroId { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual CategoríasVehículo Categoria { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    public virtual ModelosAuto ModeloNavigation { get; set; } = null!;

    public virtual Seguro Seguro { get; set; } = null!;

    public virtual ICollection<Ubicacione> Ubicaciones { get; set; } = new List<Ubicacione>();
}
