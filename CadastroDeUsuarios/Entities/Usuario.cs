namespace CadastroDeUsuarios.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
