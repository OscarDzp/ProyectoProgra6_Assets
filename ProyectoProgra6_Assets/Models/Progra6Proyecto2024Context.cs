using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgra6_Assets.Models;

public partial class Progra6Proyecto2024Context : DbContext
{
    public Progra6Proyecto2024Context()
    {
    }

    public Progra6Proyecto2024Context(DbContextOptions<Progra6Proyecto2024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<CategoríasVehículo> CategoríasVehículos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Financiamiento> Financiamientos { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<MarcasAuto> MarcasAutos { get; set; }

    public virtual DbSet<ModelosAuto> ModelosAutos { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<Seguro> Seguros { get; set; }

    public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehículo> Vehículos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("SERVER=.;DATABASE=Progra6Proyecto2024;INTEGRATED SECURITY=FALSE; TrustServerCertificate=True; Trusted_Connection=true; encrypt=false; User Id=Progra6; Password=progra6");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.CalificacionId).HasName("PK__Califica__4CF54ABE71558048");

            entity.Property(e => e.CalificacionId).HasColumnName("CalificacionID");
            entity.Property(e => e.Calificacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Comentario)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaCalificacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Fecha_calificacion");
            entity.Property(e => e.UsuarioRealizóCalificación)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Usuario_realizó_calificación");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCalificaci663865");
        });

        modelBuilder.Entity<CategoríasVehículo>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categorí__F353C1C52B54D4E7");

            entity.ToTable("Categorías_Vehículos");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7FFC339D8");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cedula).HasColumnName("cedula");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Correo_electronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C02480592118478");

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.FechaVenta).HasColumnName("Fecha_venta");
            entity.Property(e => e.FinanciamientoId).HasColumnName("FinanciamientoID");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Monto_total");
            entity.Property(e => e.NumeroFactura).HasColumnName("Numero_factura");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFacturas17011");

            entity.HasOne(d => d.Financiamiento).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.FinanciamientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFacturas207333");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFacturas569388");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFacturas90068");
        });

        modelBuilder.Entity<Financiamiento>(entity =>
        {
            entity.HasKey(e => e.FinanciamientoId).HasName("PK__Financia__9D9FEFB9D462AEFE");

            entity.Property(e => e.FinanciamientoId).HasColumnName("FinanciamientoID");
            entity.Property(e => e.CuotaMensual)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Cuota_mensual");
            entity.Property(e => e.Plazo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TasaInteres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Tasa_interes");
            entity.Property(e => e.TipoFinanciamiento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Tipo_financiamiento");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.MantenimientoId).HasName("PK__Mantenim__A62E6142F9EED4C6");

            entity.ToTable("Mantenimiento");

            entity.Property(e => e.MantenimientoId).HasColumnName("MantenimientoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DescripcionMantenimiento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Descripcion_mantenimiento");
            entity.Property(e => e.FechaFinalización).HasColumnName("Fecha_finalización");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_inicio");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMantenimie436193");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMantenimie509250");
        });

        modelBuilder.Entity<MarcasAuto>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marcas_A__D5B1CDEB723B948E");

            entity.ToTable("Marcas_Autos");

            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_marca");
        });

        modelBuilder.Entity<ModelosAuto>(entity =>
        {
            entity.HasKey(e => e.ModeloId).HasName("PK__Modelos___FA6052BA440B6A26");

            entity.ToTable("Modelos_Autos");

            entity.Property(e => e.ModeloId).HasColumnName("ModeloID");
            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.NombreModelo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_modelo");

            entity.HasOne(d => d.Marca).WithMany(p => p.ModelosAutos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKModelos_Au669660");
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol_Usua__F92302D145FCE032");

            entity.ToTable("Rol_Usuario");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.RolUsuario1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Rol_Usuario");
        });

        modelBuilder.Entity<Seguro>(entity =>
        {
            entity.HasKey(e => e.SeguroId).HasName("PK__Seguros__8B87D02A5B08B0FD");

            entity.Property(e => e.SeguroId).HasColumnName("SeguroID");
            entity.Property(e => e.CompaniaSeguros)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Compania_seguros");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_inicio");
            entity.Property(e => e.FechaVencimiento).HasColumnName("Fecha_vencimiento");
            entity.Property(e => e.TipoCobertura)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Tipo_cobertura");
        });

        modelBuilder.Entity<Ubicacione>(entity =>
        {
            entity.HasKey(e => e.UbicacionId).HasName("PK__Ubicacio__10375DF5D8D685AC");

            entity.Property(e => e.UbicacionId).HasColumnName("UbicacionID");
            entity.Property(e => e.HistorialUbicaciones)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Historial_ubicaciones");
            entity.Property(e => e.NumeroLocal).HasColumnName("Numero_local");
            entity.Property(e => e.UbicacionActual)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Ubicacion_actual");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Ubicaciones)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUbicacione15735");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7980DEEAD7F");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cedula).HasColumnName("cedula");
            entity.Property(e => e.Contrasennia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Correo_electronico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUsuario287269");
        });

        modelBuilder.Entity<Vehículo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehículo__AA0886201E5AC6B3");

            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngresoInventario).HasColumnName("Fecha_ingreso_inventario");
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModeloId).HasColumnName("ModeloID");
            entity.Property(e => e.Placa)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SeguroId).HasColumnName("SeguroID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Vehículos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKVehículos132350");

            entity.HasOne(d => d.ModeloNavigation).WithMany(p => p.Vehículos)
                .HasForeignKey(d => d.ModeloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKVehículos950429");

            entity.HasOne(d => d.Seguro).WithMany(p => p.Vehículos)
                .HasForeignKey(d => d.SeguroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKVehículos425664");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
