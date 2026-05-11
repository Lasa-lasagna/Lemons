using System.Linq.Expressions;
using MyProject.Data;
using MyProject.Entities;
using MyProject.Entities.DVO;
using MyProject.Repository;
using MyProject.Services;

namespace MyProject.Repository.Impl;

public class UsuarioRepository : IUsuarioRepository
{

    //crea un intancia del usuario

    // private readonly List<Usuario> _usuario = new();

    public readonly AppDbContext _usuario;

    public UsuarioRepository(AppDbContext usuario)
    {
        _usuario = usuario;
    }

    public int ExistThisAccount(string email, string password)
    {
        var cuenta = _usuario.Usuarios.FirstOrDefault(e=>e.Email==email && e.Password==password);
        if(cuenta is null) return 0;

        return cuenta.Id;
    }

    public List<Usuario> GetAll()
    {
        return _usuario.Usuarios.ToList();
    }

    public Usuario? GetByEmail(string email)
    {
        return _usuario.Usuarios.FirstOrDefault(u => u.Email == email);
    }


    public Usuario? GetById(int id)
    {
        return _usuario.Usuarios.FirstOrDefault(u => u.Id == id);
    }

    public DtoUsuario? GetDtoUsuario(int idSesion)
    {
        var user = _usuario.Usuarios.FirstOrDefault(u=>u.Id == idSesion);
        //Excepcion;
        var cuenta = _usuario.Cuentas.Where(e=>e.UsuarioId == idSesion).OrderByDescending(e=>e.version).FirstOrDefault();

        return Mapper.toDvo(user,cuenta);
    }

    public string? getPassword(string email)
    {
        throw new NotImplementedException();
    }

    public Boolean VerifyCuenta(int id)
    {
        // var verificar = _usuario.Usuarios.FirstOrDefault(u=>u.Id == id);
        // System.Console.WriteLine(verificar.ToString());
        // return verificar!=null?true:false;

        return _usuario.Usuarios.Any(u=>u.Id==id);
    }

    // public string? getPassword(string email)
    // {
    //     var user = _usuario.Usuarios.FirstOrDefault(u => u.Email == email);


    //     return user.Password;

    // }
}