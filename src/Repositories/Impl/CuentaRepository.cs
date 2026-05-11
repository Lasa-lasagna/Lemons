using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Entities;
using MyProject.Repository;

class CuentaRepository : ICuentaRepository
{
    private readonly AppDbContext _cuenta;

    public CuentaRepository(AppDbContext cuenta)
    {
        _cuenta = cuenta;
    }




    public Cuenta? GetCuenta(int idUsuario)
    {
        return _cuenta.Cuentas.FirstOrDefault(e => e.UsuarioId == idUsuario);
    }

        public Cuenta? GetLastCuenta(int idUsuario)
    {
        return _cuenta.Cuentas.AsNoTracking().Where(e=>e.UsuarioId == idUsuario).OrderByDescending(e=>e.version).FirstOrDefault();
    }

    public Cuenta? GetLastCuentaByEmail(string idUsuario)
    {
        return _cuenta.Cuentas.Where(e => e.Usuario.Email == idUsuario).OrderByDescending(e=>e.version).FirstOrDefault();
    }


    //Capaz de error
    public int? GetCuentaByEmail(string EmailUsuario)
    {
        return _cuenta.Cuentas.Where(e => e.Usuario.Email == EmailUsuario).Select(e=>e.UsuarioId).FirstOrDefault();
    }

    //update como tal no es porque crea otra fila
    public void UpdateCuenta(Cuenta newCuenta)
    {
        //traigo un objeto con un id=al UDserion por ello lo seteo 0 para que EF use el siguiente
        newCuenta.Id=0;
        //inmutabiliad, supongo, crea otra entrada sin afectar el saldo historico
        newCuenta.version++;

        _cuenta.Cuentas.Add(newCuenta);
        _cuenta.SaveChanges();
    }

    public bool verificarCuenta(int idUsuario)
    {
        //retorna un bool si existe algun usuario que posea estas caracteristicas
        return _cuenta.Cuentas.Any(e=>e.UsuarioId==idUsuario);
    }

    public bool verificarSaldo(int idUsuario, decimal monto)
    {
        var listaCuentas = _cuenta.Cuentas.Where(e=>e.UsuarioId==idUsuario).OrderByDescending(e=>e.version).FirstOrDefault();
        // var cuentaMonto = listaCuentas.Max(e=>e.version);
        return (monto<=listaCuentas.Saldo)?true:false;
    }
}

// Exception has occurred: CLR/System.InvalidOperationException
// An unhandled exception of type 'System.InvalidOperationException' occurred in Microsoft.EntityFrameworkCore.Relational.dll: 'Sequence contains no elements.'
//    at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
//    at System.Linq.Enumerable.TryGetSingle[TSource](IEnumerable`1 source, Boolean& found)
//    at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.ExecuteCore[TResult](Expression query, Boolean async, CancellationToken cancellationToken)
//    at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.Execute[TResult](Expression query)
//    at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryProvider.Execute[TResult](Expression expression)
//    at System.Linq.Queryable.Max[TSource,TResult](IQueryable`1 source, Expression`1 selector)
//    at CuentaRepository.verificarSaldo(Int32 idUsuario, Decimal monto) in c:\Users\destr\LAB_BIGDATA\Csahrt\Lemons\src\Repositories\Impl\CuentaRepository.cs:line 44
//    at MyProject.UI.Transaction.DefOperacion(Int32 user, Decimal monto, String otherUser) in c:\Users\destr\LAB_BIGDATA\Csahrt\Lemons\src\UI\Transaction.cs:line 71
//    at MyProject.UI.Transaction.MoveMoney(Int32 user) in c:\Users\destr\LAB_BIGDATA\Csahrt\Lemons\src\UI\Transaction.cs:line 30
//    at MyProject.UI.App.RunMyProject() in c:\Users\destr\LAB_BIGDATA\Csahrt\Lemons\src\UI\App.cs:line 40
//    at Program.Main(String[] args) in c:\Users\destr\LAB_BIGDATA\Csahrt\Lemons\Program.cs:line 15