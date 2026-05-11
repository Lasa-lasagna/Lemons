using MyProject.Services;

namespace MyProject.UI;

public class Login
{

    private readonly AuthService _autentica;
    // private String Input = "";

    public Login(AuthService autentiica)
    {
        _autentica = autentiica;
    }

    // public int ImprimirLogin()
    // {
    //     int id = 0;

    //     while (true)
    //     {

    //         System.Console.WriteLine("Bienbenido a Lemons:");
    //         System.Console.Write("Usuario: ");

    //         String Input = Console.ReadLine() ?? "";

    //         System.Console.Write("Clave: ");
    //         String Password = Console.ReadLine() ?? "";

    //         System.Console.WriteLine($"**{_autentica.login(Input, Password)}***");


    //         if (_autentica.login(Input, Password))
    //         {
    //             break;
    //         }
    //         Console.WriteLine(Input);


    //         id = _autentica.IDSesion(Input);
    //     }
    //     Console.Clear();

    //     return id;
    // }


    public int ImprimirLogin()
    {
        while (true)
        {
            Console.WriteLine("Bienvenido a Lemons:");
            Console.Write("Usuario: ");
            string input = Console.ReadLine() ?? "";

            Console.Write("Clave: ");
            string password = Console.ReadLine() ?? "";

            bool loginOk = _autentica.Login(input, password);


            if (loginOk)
            {
                Console.WriteLine($"**{loginOk}***");
                int id = _autentica.IDSesion(input);
                Console.Clear();
                return id;
            }

            Console.WriteLine("Credenciales incorrectas");
        }
    }
}