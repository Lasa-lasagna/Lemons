using System.Data.Common;

namespace MyProject.Entities;

public class Usuario
{
    public Usuario()
    {
    }

    public int Id {get; set;}
    public String Nombre {get; set;} = "";

    public String Apellido {get; set;} = "";

    public String Email {get; set;} = "";

    // ALTER TABLE "Usuarios" ADD UNIQUE ("Email");
    //agrego el tipo
    //nota debo practicar mas

    public String Password {get; set;} = "";

    // uno a muchos
    public List<Cuenta> cuentas {get; set;} = new();

    public override string ToString()
    {
        return $"Nombre: {this.Nombre}\nApellido {this.Apellido}";
    }
}