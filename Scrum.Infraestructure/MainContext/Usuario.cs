using System;
using System.Collections.Generic;

namespace Scrum.Infraestructure.MainContext;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ContraseñaHash { get; set; } = null!;

    public int IdRol { get; set; }

    public int IdPersona { get; set; }

    public virtual ICollection<ComentariosTarea> ComentariosTareas { get; set; } = new List<ComentariosTarea>();

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Tablero> Tableros { get; set; } = new List<Tablero>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
