using System;
using System.Collections.Generic;

namespace Scrum.Infraestructure.MainContext;

public partial class ComentariosTarea
{
    public int Id { get; set; }

    public int IdTarea { get; set; }

    public string Comentario { get; set; } = null!;

    public int IdUsuarioCreador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Estado { get; set; }

    public virtual Tarea IdTareaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioCreadorNavigation { get; set; } = null!;
}
