namespace MyProject.UI;
class App
{
    //final
    private readonly Login _login;
    private Menu _menu;
    private Transaction _transaction;
    private int IDSesion;

    public App(Login login, Menu menu
    ,Transaction transaction
     )
    {
        _login = login;
        _menu = menu;
        _transaction = transaction;
    }

    public void RunMyProject()
    {
        IDSesion = _login.ImprimirLogin();

        while (true)
        {
            int a = Menu.ShowMenu();
            System.Console.WriteLine($">>>>>>>>>>>>>>>[{a}]");

            switch (a)
            {
                case 1:
                //error con la sesion
                    _menu.ShowCuenta(IDSesion);
                    break;
                case 2:
                    _menu.ShowMyMoves(IDSesion);
                    break;
                //Cuarta opcion
                case 3:
                    _transaction.MoveMoney(IDSesion);
                    break;
                case 4:
                    System.Console.WriteLine("Adios");
                    Thread.Sleep(500);
                    break;
                default:
                    System.Console.WriteLine("Esto es imposible");
                    break;
            }
            //Salida del programa
            if(a==4) break;
            System.Console.Clear();
        }
    }
}