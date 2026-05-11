namespace MyProject.Entities;

public class Movimiento
{ 
    public int Id {set; get;}

    public int CuentaOrigenId {set; get;}
    public Cuenta? CuentaOrigen {get; set;}
    
    public int CuentaDestinoId {set; get;}
    public Cuenta? CuentaDestino {get; set;}

    public decimal Monto {get; set;}

    public DateTime dateTime {get;set;}

    public Movimiento(int id, int cuentaOrigenId, Cuenta cuentaOrigen, int cuentaDestinoId, Cuenta cuentaDestino, decimal monto, DateTime dateTime)
    {
        Id = id;
        CuentaOrigenId = cuentaOrigenId;
        CuentaDestinoId = cuentaDestinoId;
        Monto = monto;
        this.dateTime = DateTime.Now;
    }

    public Movimiento()
    {
    }
}


//dotnet ef migrations add Creacion del fecha

//dotnet ef database update