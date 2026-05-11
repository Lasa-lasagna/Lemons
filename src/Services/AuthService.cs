using Microsoft.EntityFrameworkCore.Diagnostics;
using MyProject.Entities;
using MyProject.Repository;

namespace MyProject.Services;

public class AuthService
{
    private readonly IUsuarioRepository _cuentaRespository;

    public AuthService(IUsuarioRepository cuentaRespository)
    {
        _cuentaRespository = cuentaRespository;
    }

    // public Boolean Login(string userEmail, string password)
    // {
    //     var a = _cuentaRespository.ExistThisAccount(userEmail, password);
    //     return a != 0 ? true : false;
    // }

    public Boolean Login(string userEmail, string password)
    {
        return _cuentaRespository.ExistThisAccount(userEmail, password) != 0;
    }


    public int IDSesion(string userEmail)
    {
        var cuenta = _cuentaRespository.GetByEmail(userEmail)
        //mejorar este manejo de exepcion
                     ?? throw new Exception("No encontrado");

        cuenta.ToString();


        return cuenta.Id;
    }

    // public String GetThisShit (String email)
    // {
    //     return _cuentaRespository.GetThis(email);
    // }

    // public void ImprimeTodo()
    // {
    //     System.Console.WriteLine("Entre aqui toma la lsita:");
    //     var list = _cuentaRespository.GetAll();

    //     foreach (var item in list)
    //     {
    //         System.Console.WriteLine(item.Email);
    //     }
    // }
}