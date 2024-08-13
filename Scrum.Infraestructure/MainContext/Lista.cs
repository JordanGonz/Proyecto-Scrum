using System;
using System.Collections.Generic;

namespace Scrum.Infraestructure.MainContext;

public partial class Lista
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTablero { get; set; }

    public int Orden { get; set; }

    public virtual Tablero IdTableroNavigation { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
