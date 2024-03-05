using System;
using System.Collections.Generic;

namespace Conexion;

public partial class Hospital
{
    public int IdHospital { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public int? AñodeConstruccion { get; set; }

    public int? Capacidad { get; set; }

    public int? IdEspecialidad { get; set; }

    public virtual Especialidad? IdEspecialidadNavigation { get; set; }


    public string Especialidad { get; set; }
}
