using System;
using System.Collections.Generic;

namespace Scrum.Infraestructure.MainContext;

public partial class Tarea
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int IdLista { get; set; }

    public int? IdUsuarioAsignado { get; set; }

    public string Estado { get; set; } = null!;

    public string? Prioridad { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public virtual ICollection<ComentariosTarea> ComentariosTareas { get; set; } = new List<ComentariosTarea>();

    public virtual Lista IdListaNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioAsignadoNavigation { get; set; }
}
