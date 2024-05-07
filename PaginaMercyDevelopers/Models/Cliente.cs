using System;
using System.Collections.Generic;

namespace PaginaMercyDevelopers.Models;

public partial class Cliente
{
    public int Idclientes { get; set; }

    public string? Rut { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public int? NúmeroTeléfono { get; set; }

    public string? País { get; set; }

    public string? Regíon { get; set; }

    public string? Dirección { get; set; }

    public int? CódigoPostal { get; set; }

    public virtual ICollection<ClientesHasServicio> ClientesHasServicios { get; set; } = new List<ClientesHasServicio>();
}
