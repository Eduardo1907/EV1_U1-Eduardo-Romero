using System;
using System.Collections.Generic;

namespace PaginaMercyDevelopers.Models;

public partial class Servicio
{
    public int Idservicios { get; set; }

    public string? Mantenimiento { get; set; }

    public string? InstalacionSistemaOperativo { get; set; }

    public string? Formateo { get; set; }

    public string? VentaHardware { get; set; }

    public string? InstalacionHardware { get; set; }

    public virtual ICollection<ClientesHasServicio> ClientesHasServicios { get; set; } = new List<ClientesHasServicio>();
}
