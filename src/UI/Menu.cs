
using System.Diagnostics;
using MyProject.Entities;
using MyProject.Entities.DVO;
using MyProject.Repository;

namespace MyProject.UI;

class Menu
{

    private readonly ICuentaRepository _cuenta;
    private readonly IUsuarioRepository _usuario;
    private readonly IMovimientoRepository _movimientos;

    public Menu(ICuentaRepository cuenta, IUsuarioRepository usuario, IMovimientoRepository movimientos)
    {
        _cuenta = cuenta;
        _usuario = usuario;
        _movimientos = movimientos;
    }

    public static int ShowMenu()
    {
        System.Console.WriteLine("=======================================");
        System.Console.WriteLine("       INGRESAR AL SISTEMA LEMON       ");
        System.Console.WriteLine("=======================================");
        System.Console.WriteLine(" 1.- Ver estado de cuenta      ");
        System.Console.WriteLine(" 2.- Ver mis movimientos  ");
        System.Console.WriteLine(" 3.- Reliazar una transaccion  ");
        System.Console.WriteLine(" 4.- Salir  ");
        int.TryParse(System.Console.ReadLine(), out int opcion);

        if (opcion != 1 && opcion != 2)
        {
            Console.Write("ERROR, la opción escrita no cumple");
        }
        Thread.Sleep(2000);
        Console.Clear();

        return opcion;
    }

    public void ShowCuenta(int sesion)
    {
        DtoUsuario usuario = _usuario.GetDtoUsuario(sesion);
        // Aqui esta el error
        ModelCard(usuario);

        Console.Write("PRESS OK...");
        Console.ReadLine();
        Console.Clear();

    }

    public void ShowMyMoves(int sesion)
    {
        List<Movimiento> myList = _movimientos.MyListMove(sesion) ?? new List<Movimiento>();

        CardList(myList);
        Console.Write("PRESS OK...");
        Console.ReadLine();
        Console.Clear();
    }


    static void ModelCard(DtoUsuario cuenta)
    {
        System.Console.WriteLine(
            // $"CARD de {cuenta.Usuario.Nombre} {cuenta.Usuario.Apellido}\n" +
            // $"V: {cuenta.Id} - Saldo: {cuenta.Saldo}\n"

            $"Fecha Actual: {DateTime.UtcNow}\n"+
            $"Nombre: {cuenta.Nombre+" "+cuenta.Apellido} - Email: {cuenta.Email}\n"+
            $"Saldo Actual: {cuenta.Saldo}"            
        );
    }


    static void CardList(List<Movimiento> lista)
    {
        if (lista != null)
        {
            foreach (var a in lista)
            {
                System.Console.WriteLine(
                    $"ID TRANSACCION {a.Id}\n" +
                    $"Cuenta de destino: {a.CuentaDestinoId} || Fecha: {a.dateTime}\n" +
                    $"Cuenta de destino: {a.CuentaDestino.Usuario.Email} || Fecha: {a.dateTime}\n" +
                    $"Monto de la transaccion: {a.Monto}\n"
                );
            }
        }
        else
        {
            System.Console.WriteLine("No posee movimientos");
        }
    }
}