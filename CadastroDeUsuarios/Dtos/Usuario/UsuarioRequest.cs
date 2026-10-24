namespace CadastroDeUsuarios.Dtos.Usuario
{

    public class UsuarioRequest
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
       
    }
}
