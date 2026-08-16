using Microsoft.EntityFrameworkCore;
using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Data
{
    public class AupadDbContext : DbContext
    {
        public AupadDbContext(DbContextOptions<AupadDbContext> options) : base(options)
        {
        }

        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<CategoriaSeguro> CategoriaSeguro { get; set; }
        public DbSet<CompaniaSeguro> CompaniaSeguro { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConfiguracionSistema> ConfiguracionesSistema { get; set; }
        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<DocumentoPoliza> DocumentosPoliza { get; set; }
        public DbSet<CuotaPoliza> CuotasPoliza { get; set; }
        public DbSet<BeneficiarioPoliza> BeneficiariosPoliza { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("tipos_documento");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
                entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(255);
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<CategoriaSeguro>(entity =>
            {
                entity.ToTable("categorias_seguro");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
                entity.Property(e => e.CategoriaPadreId).HasColumnName("categoria_padre_id");
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<CompaniaSeguro>(entity =>
            {
                entity.ToTable("companias_seguro");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
                entity.Property(e => e.Ruc).HasColumnName("ruc").HasMaxLength(11);
                entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(20);
                entity.Property(e => e.Correo).HasColumnName("correo").HasMaxLength(120);
                entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(255);
                entity.Property(e => e.PaginaWeb).HasColumnName("pagina_web").HasMaxLength(150);
                entity.Property(e => e.ContactoComercial).HasColumnName("contacto_comercial").HasMaxLength(120);
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.TipoCliente).HasColumnName("tipo_cliente").HasConversion<string>();
                entity.Property(e => e.TipoDocumento).HasColumnName("tipo_documento").HasConversion<string>();
                entity.Property(e => e.NumeroDocumento).HasColumnName("numero_documento").HasMaxLength(20).IsRequired();
                entity.HasIndex(e => e.NumeroDocumento).IsUnique();
                entity.Property(e => e.NombreRazonSocial).HasColumnName("nombre_razon_social").HasMaxLength(200).IsRequired();
                entity.Property(e => e.Correo).HasColumnName("correo").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(15).IsRequired();
                entity.Property(e => e.Direccion).HasColumnName("direccion");
                entity.Property(e => e.Observaciones).HasColumnName("observaciones");
                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id").IsRequired();
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("roles");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.RolId).HasColumnName("rol_id").IsRequired();
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Apellido).HasColumnName("apellido").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Correo).HasColumnName("correo").HasMaxLength(150).IsRequired();
                entity.HasIndex(e => e.Correo).IsUnique();
                entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasMaxLength(255).IsRequired();
                entity.Property(e => e.Estado).HasColumnName("estado").HasConversion<string>();
                entity.Property(e => e.IngresoConfirmado).HasColumnName("ingreso_confirmado");
                entity.Property(e => e.RequiereCambioPassword).HasColumnName("requiere_cambio_password");
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<ConfiguracionSistema>(entity =>
            {
                entity.ToTable("configuracion_sistema");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Clave).HasColumnName("clave").HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.Clave).IsUnique();
                entity.Property(e => e.Valor).HasColumnName("valor").HasMaxLength(255).IsRequired();
                entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(255);
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.ToTable("seguros");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CategoriaId).HasColumnName("categoria_id").IsRequired();
                entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(20).IsRequired();
                entity.HasIndex(e => e.Codigo).IsUnique();
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.ToTable("polizas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ClienteId).HasColumnName("cliente_id").IsRequired();
                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id").IsRequired();
                entity.Property(e => e.SeguroId).HasColumnName("seguro_id").IsRequired();
                entity.Property(e => e.NumeroPoliza).HasColumnName("numero_poliza").HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.NumeroPoliza).IsUnique();
                entity.Property(e => e.CompaniaId).HasColumnName("compania_id").IsRequired();
                entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
                entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
                entity.Property(e => e.VigenciaMeses).HasColumnName("vigencia_meses");
                entity.Property(e => e.Cobertura).HasColumnName("cobertura").HasMaxLength(255);
                entity.Property(e => e.SumaAsegurada).HasColumnName("suma_asegurada").HasPrecision(12, 2);
                entity.Property(e => e.PeriodicidadPago).HasColumnName("periodicidad_pago").HasConversion<string>();
                entity.Property(e => e.Moneda).HasColumnName("moneda").HasConversion<string>();
                entity.Property(e => e.PrimaNeta).HasColumnName("prima_neta").HasPrecision(12, 2);
                entity.Property(e => e.ComisionPorcentaje).HasColumnName("comision_porcentaje").HasPrecision(5, 2);
                entity.Property(e => e.FechaNotificacion).HasColumnName("fecha_notificacion");
                entity.Property(e => e.CuotasPendientes).HasColumnName("cuotas_pendientes");
                entity.Property(e => e.CuotasPagadas).HasColumnName("cuotas_pagadas");
                entity.Property(e => e.PolizaAnteriorId).HasColumnName("poliza_anterior_id");
                entity.Property(e => e.Estado).HasColumnName("estado").HasConversion<string>();
                entity.Property(e => e.DocumentoPrincipalId).HasColumnName("documento_principal_id");
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<DocumentoPoliza>(entity =>
            {
                entity.ToTable("documento_poliza");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PolizaId).HasColumnName("poliza_id").IsRequired();
                entity.Property(e => e.TipoDocumentoId).HasColumnName("tipo_documento_id").IsRequired();
                entity.Property(e => e.NombreArchivo).HasColumnName("nombre_archivo").HasMaxLength(255).IsRequired();
                entity.Property(e => e.UrlArchivo).HasColumnName("url_archivo").IsRequired();
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<CuotaPoliza>(entity =>
            {
                entity.ToTable("cuotas_poliza");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PolizaId).HasColumnName("poliza_id").IsRequired();
                entity.Property(e => e.NumeroCuota).HasColumnName("numero_cuota").IsRequired();
                entity.Property(e => e.Monto).HasColumnName("monto").HasPrecision(12, 2).IsRequired();
                entity.Property(e => e.FechaVencimientoCuota).HasColumnName("fecha_vencimiento_cuota").IsRequired();
                entity.Property(e => e.Estado).HasColumnName("estado").HasConversion<string>();
                entity.Property(e => e.MontoPagado).HasColumnName("monto_pagado").HasPrecision(12, 2);
                entity.Property(e => e.FechaPago).HasColumnName("fecha_pago");
                entity.Property(e => e.MetodoPago).HasColumnName("metodo_pago").HasConversion<string>();
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });

            modelBuilder.Entity<BeneficiarioPoliza>(entity =>
            {
                entity.ToTable("beneficiarios_poliza");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PolizaId).HasColumnName("poliza_id").IsRequired();
                entity.Property(e => e.Dni).HasColumnName("dni").HasMaxLength(15).IsRequired();
                entity.Property(e => e.Nombres).HasColumnName("nombres").HasMaxLength(150).IsRequired();
                entity.Property(e => e.Cargo).HasColumnName("cargo").HasMaxLength(100);
                entity.Property(e => e.Remuneracion).HasColumnName("remuneracion").HasPrecision(10, 2);
                entity.Property(e => e.Mes).HasColumnName("mes").IsRequired();
                entity.Property(e => e.Anio).HasColumnName("anio").IsRequired();
                entity.HasIndex(e => new { e.PolizaId, e.Dni, e.Mes, e.Anio }).IsUnique();
                entity.Property(e => e.Estado).HasColumnName("estado").HasConversion<string>();
                entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
                entity.Property(e => e.ActualizadoEn).HasColumnName("actualizado_en");
                entity.Property(e => e.UsuarioCreoId).HasColumnName("usuario_creo_id");
                entity.Property(e => e.UsuarioActualizoId).HasColumnName("usuario_actualizo_id");
            });
        }
    }
}
