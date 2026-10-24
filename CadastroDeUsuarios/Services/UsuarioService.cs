using CadastroDeUsuarios.Dtos.Usuario;
using CadastroDeUsuarios.Entities;
using CadastroDeUsuarios.Interfaces;

namespace CadastroDeUsuarios.Services
{
  
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> CreateUsuarioAsync(UsuarioRequest usuario)
        {
            var newUsuario = new Usuario
            {
                Nome = usuario.Nome,
                Cpf = usuario.Cpf,
                Email = usuario.Email,
                Endereco = usuario.Endereco,
                Telefone = usuario.Telefone
            };

            return await _usuarioRepository.CreateUsuarioAsync(newUsuario);
        }

        public async Task<IEnumerable<UsuarioResponse>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
            return usuarios.Select(u => new UsuarioResponse
            {
                Id = u.Id,
                Nome = u.Nome,
                DataCadastro = u.DataCadastro
            });
        }
    }
}
