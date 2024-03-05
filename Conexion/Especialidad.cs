using System;
using System.Collections.Generic;

namespace Conexion;

public partial class Especialidad
{
    public int IdEspecialidad { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
}
