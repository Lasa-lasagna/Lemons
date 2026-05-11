using MyProject.Entities;

namespace MyProject.Repository;
interface ICuentaRepository
{
    Cuenta? GetCuenta(int idUsuario);



    int? GetCuentaByEmail(string EmailUsuario);
    Cuenta? GetLastCuentaByEmail(string idUsuario);

    void UpdateCuenta(Cuenta cuenta);

    //verifica el saldo de la cuenta
    Boolean verificarSaldo(int idUsuario, decimal monto);


    //verifica si la cuenta existe
    Boolean verificarCuenta(int idUsuario);

    Cuenta? GetLastCuenta(int idUsuario);

}