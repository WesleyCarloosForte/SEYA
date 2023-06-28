using Microsoft.EntityFrameworkCore;
using SEYA.APP.Shared.Models;

namespace SEYA.APP.Server.Data
{
    public class ServerContex : DbContext
    {
        public ServerContex(DbContextOptions<ServerContex> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Deuda> Deudas { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Pago> Pagos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionarios");

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
            new Rol { ID = 1, RolName = "Administrador" },
            new Rol { ID = 2, RolName = "Funcionario" }
            );

            modelBuilder.Entity<Funcionario>().HasData(new Funcionario
            {
                Id = 1,
                Nombre="Administrador del sistema",
                Apellido="Administrador",
                Cedula="0.000.000",
                Correo="administrador@gmail.com",
                Direccion="CDE",
                RolId=1,
                Telefono="0985555530"
            });
        }
    }
}
