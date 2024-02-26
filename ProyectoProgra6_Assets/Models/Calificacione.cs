using System;
using System.Collections.Generic;

namespace ProyectoProgra6_Assets.Models;

public partial class Calificacione
{
    public int CalificacionId { get; set; }

    public string? Calificacion { get; set; }

    public string? Comentario { get; set; }

    public string? FechaCalificacion { get; set; }

    public string? UsuarioRealizóCalificación { get; set; }

    public int VehiculoId { get; set; }

    public virtual Vehículo Vehiculo { get; set; } = null!;
}
