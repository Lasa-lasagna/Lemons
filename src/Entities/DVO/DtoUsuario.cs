namespace MyProject.Entities.DVO;

public record DtoUsuario
(
    String Nombre,
    String Apellido,
    String Email,
    decimal Saldo
)
{
    //contructor vacio
    public DtoUsuario():this(default!){}
}