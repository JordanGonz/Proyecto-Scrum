using System;
using System.Collections.Generic;

namespace Scrum.Infraestructure.MainContext;

public partial class Tablero
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int IdUsuarioCreador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario IdUsuarioCreadorNavigation { get; set; } = null!;

    public virtual ICollection<Lista> Lista { get; set; } = new List<Lista>();
}
