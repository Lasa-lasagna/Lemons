using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Entities;
using MyProject.Repository;
using MyProject.Repository.Impl;


class MovimientoRepository : IMovimientoRepository
{
    private readonly AppDbContext _movimientos;
    private readonly IUsuarioRepository _user;
    private readonly ICuentaRepository _cuenta;

    public MovimientoRepository(AppDbContext movimientos, IUsuarioRepository user, ICuentaRepository cuenta)
    {
        _movimientos = movimientos;
        _user = user;
        _cuenta = cuenta;
    }

    public bool MoveMoney(Cuenta tramiteWho, decimal monto, Cuenta tramiteTo)
    {

        // var cuentaOther = _cuenta.GetLastCuentaByEmail(tramiteTo);
        /*
            Esta operacion solo debe realizar la operacion
            <antes verifica la existencia caso no, no procede>
        */
        // Boolean a = _user.VerifyCuenta(tramiteWho);
        System.Console.WriteLine(_user.VerifyCuenta(tramiteTo.UsuarioId));

        Console.Read();

        if (!_user.VerifyCuenta(tramiteTo.UsuarioId))
        {
            return false;
        }

        var movimiento = new Movimiento
        {
            CuentaOrigenId = tramiteWho.Id,
            CuentaDestinoId = tramiteTo.Id,
            Monto = monto,
            dateTime = DateTime.UtcNow
        };

        _movimientos.Movimientos.Add(movimiento);
        try
        {
            return _movimientos.SaveChanges()>0;

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    // Exception has occurred: CLR/Microsoft.EntityFrameworkCore.DbUpdateException
    // An unhandled exception of type 'Microsoft.EntityFrameworkCore.DbUpdateException' occurred in Microsoft.EntityFrameworkCore.dll: 'An error occurred while saving the entity changes. See the inner exception for details.'
    //  Inner exceptions found, see $exception in variables window for more details.
    //  Innermost exception 	 System.ArgumentException : Cannot write DateTime with Kind=Local to PostgreSQL type 'timestamp with time zone', only UTC is supported. Note that it's not possible to mix DateTimes with different Kinds in an array, range, or multirange. (Parameter 'value')
    //    at Npgsql.Internal.Converters.DateTimeConverterResolver`1.Get(DateTime value, Nullable`1 expectedPgTypeId, Boolean validateOnly)
    //    at Npgsql.Internal.Converters.DateTimeConverterResolver.<>c.<CreateResolver>b__0_0(DateTimeConverterResolver`1 resolver, DateTime value, Nullable`1 expectedPgTypeId)
    //    at Npgsql.Internal.Converters.DateTimeConverterResolver`1.Get(T value, Nullable`1 expectedPgTypeId)
    //    at Npgsql.Internal.PgConverterResolver`1.GetAsObjectInternal(PgTypeInfo typeInfo, Object value, Nullable`1 expectedPgTypeId)
    //    at Npgsql.Internal.PgResolverTypeInfo.GetResolutionAsObject(Object value, Nullable`1 expectedPgTypeId)
    //    at Npgsql.Internal.PgTypeInfo.GetObjectResolution(Object value)
    //    at Npgsql.NpgsqlParameter.ResolveConverter(PgTypeInfo typeInfo)
    //    at Npgsql.NpgsqlParameter.ResolveTypeInfo(PgSerializerOptions options)
    //    at Npgsql.NpgsqlParameterCollection.ProcessParameters(PgSerializerOptions options, Boolean validateValues, CommandType commandType)
    //    at Npgsql.NpgsqlCommand.<ExecuteReader>d__120.MoveNext()
    //    at Npgsql.NpgsqlCommand.<ExecuteReader>d__120.MoveNext()
    //    at System.Runtime.CompilerServices.ValueTaskAwaiter`1.GetResult()
    //    at Npgsql.NpgsqlCommand.ExecuteReader(CommandBehavior behavior)
    //    at Npgsql.NpgsqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
    //    at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
    //    at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)



    public List<Movimiento>? MyListMove(int idUSer)
    {
        return _movimientos.Movimientos
                            //curiosa sintaxis
                            .Include(m=>m.CuentaDestino)
                            .ThenInclude(c=>c.Usuario)

                            .Where(e => e.CuentaOrigen.UsuarioId == idUSer)
                            .OrderBy(e => e.dateTime)
                            .ToList()
                            ?? throw new Exception("ERRROR");
    }
}