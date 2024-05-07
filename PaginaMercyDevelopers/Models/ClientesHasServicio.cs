using System;
using System.Collections.Generic;

namespace PaginaMercyDevelopers.Models;

public partial class ClientesHasServicio
{
    public int ClientesIdclientes { get; set; }

    public int ServiciosIdservicios { get; set; }

    public DateOnly? Inicio { get; set; }

    public DateOnly? Termino { get; set; }

    public int? Coste { get; set; }

    public string? Tecnico { get; set; }

    public int? NumeroTecnico { get; set; }

    public string? CorreoTecnico { get; set; }

    public string? Direccion { get; set; }

    public string? ClientesHasServicioscol { get; set; }

    public virtual Cliente ClientesIdclientesNavigation { get; set; } = null!;

    public virtual Servicio ServiciosIdserviciosNavigation { get; set; } = null!;
}
