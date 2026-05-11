using MyProject.Entities;
using MyProject.Repository;

namespace MyProject.UI;

class Transaction
{
    private readonly ICuentaRepository _cuenta;
    private readonly IMovimientoRepository _movimiento;

    public Transaction(ICuentaRepository cuenta, IMovimientoRepository movimiento)
    {
        _cuenta = cuenta;
        _movimiento = movimiento;
    }

    public Boolean MoveMoney(int user)
    {

        // es el destinatario
        var a = _cuenta.GetCuentaByEmail(DineroPara());
        // int.TryParse(System.Console.ReadLine(), out int opcion);


        //si la cuenta no existe pasa eso
        //Si es falso entra y se rompe el bucle
        // if (!a.HasValue) return false;
        if (a == 0) return false;


        var b = IngresaMonto();

        //verifica mi saldo, si es factible o no
        if (!_cuenta.verificarSaldo(user, b)) return false;

        DefOperacion(user, b, a.Value);

        // if (!_cuenta.verificarSaldo(b)) return false;

        return true;
    }



    //vistas
    static string DineroPara()
    {
        System.Console.WriteLine("Ingrese el correo de la cuenta :");
        return Console.ReadLine();
    }



    //Error
    static decimal IngresaMonto()
    {
        System.Console.WriteLine("Ingresa el monto: ");


        //dario -> 
        decimal.TryParse(Console.ReadLine(), out decimal opcion);

        System.Console.WriteLine(">>>>MONTO>>>>" + opcion);

        Thread.Sleep(1000);
        return opcion;
    }

    //logic


    void DefOperacion(int user, decimal monto, int otherUser)
    {
        Cuenta? myCuenta = _cuenta.GetLastCuenta(user);
        Cuenta? otherCuenta = _cuenta.GetLastCuenta(otherUser);

        //actualizaSaldos
        myCuenta.UpdateCuenta(monto, 0);
        otherCuenta.UpdateCuenta(monto, 1);


        // cuenta.Saldo-=monto;

        // //inmutabiliad
        // cuenta.version++;

        if (_movimiento.MoveMoney(myCuenta, monto, otherCuenta))
        {
            _cuenta.UpdateCuenta(myCuenta);
            _cuenta.UpdateCuenta(otherCuenta);
            System.Console.WriteLine("Actualizaron:::");
        }


    }
}