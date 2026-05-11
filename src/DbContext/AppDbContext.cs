using Microsoft.EntityFrameworkCore;
using MyProject.Entities;

namespace MyProject.Data;

//Esto inicia las migraciones creando el archivo de migraciones
// por ende mapeara los cambios de la db en vez de consultar aun archivo supongo, osea a las clases
// caso sea falso, me falta consultar/investigar


// *dotnet ef migrations add Init*
public class AppDbContext : DbContext
{
    //Aqui defino la creacion de mis clases a tablas
    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Cuenta> Cuentas {get; set;}

    public DbSet<Movimiento> Movimientos {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        //Cambiar despues
        optionsBuilder.UseNpgsql("Host=localhost;Database=lemons;Username=amargo;Password=amargaret");
    }
    //C# busca esta clase y la ejecuta
    //comand = dotnet ef database update

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movimiento>()
            .HasOne(m=>m.CuentaOrigen)
            .WithMany(c=>c.MovimientosOrigen)
            .HasForeignKey(m=>m.CuentaOrigenId);
        
        modelBuilder.Entity<Movimiento>()
            .HasOne(m=>m.CuentaDestino)
            .WithMany(c=>c.MovimientosDestino)
            .HasForeignKey(m=>m.CuentaDestinoId);
    }


}
