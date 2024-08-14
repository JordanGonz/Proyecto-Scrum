using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Scrum.Infraestructure.MainContext;

public partial class ScrumManagementContext : DbContext
{
    public ScrumManagementContext()
    {
    }

    public ScrumManagementContext(DbContextOptions<ScrumManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComentariosTarea> ComentariosTareas { get; set; }

    public virtual DbSet<Lista> Listas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tablero> Tableros { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ScrumDb;User Id=sa;Password=123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComentariosTarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC07BD59FEFB");

            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.ComentariosTareas)
                .HasForeignKey(d => d.IdTarea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__IdTar__4E88ABD4");

            entity.HasOne(d => d.IdUsuarioCreadorNavigation).WithMany(p => p.ComentariosTareas)
                .HasForeignKey(d => d.IdUsuarioCreador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__IdUsu__4F7CD00D");
        });

        modelBuilder.Entity<Lista>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Listas__3214EC07819E5516");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTableroNavigation).WithMany(p => p.Lista)
                .HasForeignKey(d => d.IdTablero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Listas__IdTabler__45F365D3");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personas__3214EC07788D0594");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Personas__531402F3A44BFCC9").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07F4C9B2B3");

            entity.HasIndex(e => e.NombreRol, "UQ__Roles__4F0B537FE2AD5CA5").IsUnique();

            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tablero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tableros__3214EC07420A2BFC");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreadorNavigation).WithMany(p => p.Tableros)
                .HasForeignKey(d => d.IdUsuarioCreador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tableros__IdUsua__4316F928");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tareas__3214EC0796271CBA");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdListaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdLista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tareas__IdLista__49C3F6B7");

            entity.HasOne(d => d.IdUsuarioAsignadoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdUsuarioAsignado)
                .HasConstraintName("FK__Tareas__IdUsuari__4AB81AF0");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07B2B4A31E");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE09B30B98A").IsUnique();

            entity.Property(e => e.ContraseñaHash)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdPers__3F466844");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdRol__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
