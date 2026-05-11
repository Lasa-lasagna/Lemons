using MyProject.Entities;
using MyProject.Entities.DVO;
namespace MyProject.Repository;

public interface IUsuarioRepository
{

    int ExistThisAccount(String email, String password);

    DtoUsuario? GetDtoUsuario(int idSesion);

    Usuario? GetById(int id);
    Usuario? GetByEmail(String email);
    String? getPassword(String email);

    Boolean VerifyCuenta(int id);


    List<Usuario> GetAll();
}