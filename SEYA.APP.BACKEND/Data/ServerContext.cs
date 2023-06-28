using Microsoft.EntityFrameworkCore;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.BACKEND.Data
{
    public class ServerContex : DbContext
    {
        public ServerContex(DbContextOptions<ServerContex> options) : base(options)
        {
        }
        public ServerContex()
        {


        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Deuda> Deudas { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionarios");
            modelBuilder.Entity<Comprobante>().ToTable("Comprobantes");

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Cuota)
                .WithMany()
                .HasForeignKey(p => p.CuotaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cuota>()
                .Property(c => c.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Deuda>()
                .Property(d => d.ValorTotal)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Rol>().HasData(
            new Rol { Id = 1, RolName = "Administrador" },
            new Rol { Id = 2, RolName = "Funcionario" }
            );

            modelBuilder.Entity<Comprobante>().HasData(new Comprobante
            {
                Descripcion="Facutra",
                FinVigencia=DateTime.Now.AddMonths(6),
                InicioVigencia=DateTime.Now,
                NumeroActual=201,
                NumeroFinal=600,
                Id=1,
                Timbrado="2343242",
                Sucursal="001",
                PuntoExpedicion="001"

            });

            modelBuilder.Entity<Funcionario>().HasData(new Funcionario
            {
                Id = 1,
                Nombre="Administrador del sistema",
                Apellido="Administrador",
                Cedula="0.000.000",
                Correo="administrador@gmail.com",
                Direccion="CDE",
                RolId=1,
                Telefono="0985555530",
                Password="123456",
                UserName="admin"
            });
        }
    }
}
