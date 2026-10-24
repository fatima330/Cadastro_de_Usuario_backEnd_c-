using CadastroDeUsuarios.Entities;

namespace CadastroDeUsuarios.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<int> CreateUsuarioAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
    }
}
