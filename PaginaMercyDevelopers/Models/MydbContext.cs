using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PaginaMercyDevelopers.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClientesHasServicio> ClientesHasServicios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idclientes).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.Idclientes)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idclientes");
            entity.Property(e => e.Apellido).HasMaxLength(30);
            entity.Property(e => e.Correo).HasMaxLength(255);
            entity.Property(e => e.CódigoPostal)
                .HasColumnType("int(11)")
                .HasColumnName("Código_Postal");
            entity.Property(e => e.Dirección).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(30);
            entity.Property(e => e.NúmeroTeléfono)
                .HasColumnType("int(11)")
                .HasColumnName("Número_Teléfono");
            entity.Property(e => e.País).HasMaxLength(30);
            entity.Property(e => e.Regíon).HasMaxLength(255);
            entity.Property(e => e.Rut)
                .HasMaxLength(10)
                .HasColumnName("RUT")
                .UseCollation("armscii8_general_ci")
                .HasCharSet("armscii8");
        });

        modelBuilder.Entity<ClientesHasServicio>(entity =>
        {
            entity.HasKey(e => new { e.ClientesIdclientes, e.ServiciosIdservicios })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("clientes_has_servicios");

            entity.HasIndex(e => e.ClientesIdclientes, "fk_clientes_has_servicios_clientes_idx");

            entity.HasIndex(e => e.ServiciosIdservicios, "fk_clientes_has_servicios_servicios1_idx");

            entity.Property(e => e.ClientesIdclientes)
                .HasColumnType("int(11)")
                .HasColumnName("clientes_idclientes");
            entity.Property(e => e.ServiciosIdservicios)
                .HasColumnType("int(11)")
                .HasColumnName("servicios_idservicios");
            entity.Property(e => e.ClientesHasServicioscol)
                .HasMaxLength(45)
                .HasColumnName("clientes_has_servicioscol");
            entity.Property(e => e.CorreoTecnico)
                .HasMaxLength(255)
                .HasColumnName("correo_tecnico");
            entity.Property(e => e.Coste)
                .HasColumnType("int(11)")
                .HasColumnName("coste");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Inicio).HasColumnName("inicio");
            entity.Property(e => e.NumeroTecnico)
                .HasColumnType("int(11)")
                .HasColumnName("numero_tecnico");
            entity.Property(e => e.Tecnico)
                .HasMaxLength(255)
                .HasColumnName("tecnico");
            entity.Property(e => e.Termino).HasColumnName("termino");

            entity.HasOne(d => d.ClientesIdclientesNavigation).WithMany(p => p.ClientesHasServicios)
                .HasForeignKey(d => d.ClientesIdclientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clientes_has_servicios_clientes");

            entity.HasOne(d => d.ServiciosIdserviciosNavigation).WithMany(p => p.ClientesHasServicios)
                .HasForeignKey(d => d.ServiciosIdservicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clientes_has_servicios_servicios1");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Idservicios).HasName("PRIMARY");

            entity.ToTable("servicios");

            entity.Property(e => e.Idservicios)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idservicios");
            entity.Property(e => e.Formateo).HasMaxLength(255);
            entity.Property(e => e.InstalacionHardware)
                .HasMaxLength(255)
                .HasColumnName("Instalacion_hardware");
            entity.Property(e => e.InstalacionSistemaOperativo)
                .HasMaxLength(255)
                .HasColumnName("Instalacion_sistema_operativo");
            entity.Property(e => e.Mantenimiento).HasMaxLength(255);
            entity.Property(e => e.VentaHardware)
                .HasMaxLength(255)
                .HasColumnName("Venta_hardware");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
