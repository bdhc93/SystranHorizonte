using System.Data.Entity;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Mapping;

namespace SystranHorizonte.Repository
{
    public class SystranHorizonteContext : DbContext
    {
        public SystranHorizonteContext()
        {
            //Database.SetInitializer<SystranHorizonteContext>(new DropCreateDatabaseAlways<SystranHorizonteContext>());
            Database.SetInitializer<SystranHorizonteContext>(null);
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Estacion> Estaciones { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<VentaPasaje> VentaPasajes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carga> Cargas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaAsientos> VentaAsientos { get; set; }
        public DbSet<VentaEncomienda> VentaEncomiendas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Roles> Roless { get; set; }
        public DbSet<DetalleUsuario> DetalleUsuarios { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VehiculosMap());
            modelBuilder.Configurations.Add(new EstacionesMap());
            modelBuilder.Configurations.Add(new HorarioMap());
            modelBuilder.Configurations.Add(new VentaPasajeMap());
            modelBuilder.Configurations.Add(new EmpleadoMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new CargaMap());
            modelBuilder.Configurations.Add(new VentaMap());
            modelBuilder.Configurations.Add(new VentaAsientosMap());
            modelBuilder.Configurations.Add(new VentaEncomiendaMap());
            modelBuilder.Configurations.Add(new ReservaMap());
            modelBuilder.Configurations.Add(new RolesMap());
            modelBuilder.Configurations.Add(new DetalleUsuarioMap());
            modelBuilder.Configurations.Add(new AccountMap());
        }
    }
}