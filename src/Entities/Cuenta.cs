using System.Data.Common;

namespace MyProject.Entities;

public class Cuenta
{
    public Cuenta()
    {
    }

    // public Cuenta(int id, int usuarioId, decimal saldo, int version, List<Movimiento> movimientosOrigen, List<Movimiento> movimientosDestino)
    // {
    //     Id = id;
    //     UsuarioId = usuarioId;
    //     Saldo = saldo;
    //     this.version = version;
    //     MovimientosOrigen = movimientosOrigen;
    //     MovimientosDestino = movimientosDestino;
    // }

    public int Id { get; set; }

    //FK
    public int UsuarioId { get; set; } = 0;

    public decimal Saldo { get; set; } = 0;

    public int version { get; set; } = 0;


    // Navegación???
    //segunyipiyi: Es como moverte entre objetos sin SQL.
    public Usuario? Usuario { get; set; }

    public List<Movimiento> MovimientosOrigen { get; set; } = new();
    public List<Movimiento> MovimientosDestino { get; set; } = new();


    public override string ToString()
    {
        return $"Id: {this.Id}\nSaldo: {this.Saldo}";
    }

    //1 suma, 0 resta
    // public Cuenta UpdateCuenta(decimal monto, int operacion)
    // {
    //     version++;

    //     if (operacion.Equals(1))
    //     {
    //         Saldo += monto;
    //     }
    //     else if (operacion.Equals(0))
    //     {
    //         Saldo -= monto;
    //     }
    //     else
    //     {
    //         System.Console.WriteLine("Operacion no valida");
    //     }
    //     return new Cuenta
    //     {
    //         Saldo = this.Saldo + monto
    //     };

    // }
    public void UpdateCuenta(decimal monto, int operacion)
    {   
        if (operacion == 1)
            Saldo += monto;
        else
            Saldo -= monto;
    }

    // public Cuenta? UpdateNowCuenta(Cuenta cuenta, int operacion,decimal monto)
    // {   
    //     return new Cuenta {
    //         UsuarioId = cuenta.UsuarioId,
    //         Saldo = (operacion == 1)? cuenta.Saldo+=monto: cuenta.Saldo-=monto,
    //         version = cuenta.version + 1
    //     };
    // }
}