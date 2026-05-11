namespace MyProject.Services;

using MyProject.Entities;
using MyProject.Entities.DVO;

static class Mapper
{
    public static DtoUsuario toDvo(Usuario? usuario,Cuenta? cuenta)
    {
        return new DtoUsuario(usuario.Nombre,usuario.Apellido,usuario.Email,cuenta.Saldo);
    }

}