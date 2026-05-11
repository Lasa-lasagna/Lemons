using MyProject.UI;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Injection;


class Program
{
    static void Main(string[] args)
    {
        var provider = DInject.Configure();

        var app = provider.GetRequiredService<App>();

        // App app = new();
        app.RunMyProject();

    //     List<Estudiante> listEstudiante = new();

    //     listEstudiante.Add(new Estudiante("1","pablo",2));

    //     listEstudiante.Add(new Estudiante("2", "pedro", 3));

    //     listEstudiante.Add(new Estudiante("3", "irma", 10));

    //     listEstudiante.Add(new Estudiante("4", "claudio", 5));

    //     var newList = listEstudiante
    // .Where(e => e.Nota < 5)
    // .Select(e => $"{e.Name}.Ganador")
    // .ToList();

    //     newList.ForEach(Console.WriteLine);

    //     var hola = Console.ReadLine();

        //     Console.WriteLine("Hello, World!");

        //     AppDbContext dbContext = new AppDbContext();

        //     IUsuarioRepository cuentaRepo = new UsuarioRepository(dbContext);

        //     AuthService auth = new AuthService(cuentaRepo);

        //     String userInput = "";

        //     while (true)
        //     {
        //         System.Console.Write("Ingrese su usuario: ");
        //         userInput = Console.ReadLine();

        //         // System.Console.WriteLine(auth.GetThisShit(userInput)+"<<<<");

        //         // System.Console.WriteLine("_________");    

        //         if (auth.login(userInput, "Hola"))
        //         {
        //             Console.WriteLine("Ingreso");
        //             break;
        //         }
        //         System.Console.WriteLine("Intenta otra vez");
        //     }




    }


   
}


// margo@works.com

// INSERT INTO "Usuarios" ("Nombre","Apellido","Email","Password") VALUES ('Brisa','Lupilla','brisa@works.com','brisarama');