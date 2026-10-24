using CadastroDeUsuarios.Entities;
using CadastroDeUsuarios.Interfaces;
using Dapper;
using System.Data;

namespace CadastroDeUsuarios.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");
        }
        public async Task<int> CreateUsuarioAsync(Usuario usuario)
        {
            const string sql = @"INSERT INTO TB_USUARIO
                (ID_USUARIO,NOME, CPF, EMAIL, ENDERECO, TELEFONE) 
            VALUES (TB_USUARIOS_SEQ.NEXTVAL, :Nome, :Cpf, :Email, :Endereco, :Telefone)
            RETURNING ID_USUARIO INTO :Id";

            using var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add(":Nome", usuario.Nome);
            parameters.Add(":Cpf", usuario.Cpf);
            parameters.Add(":Email", usuario.Email);
            parameters.Add(":Endereco", usuario.Endereco);
            parameters.Add(":Telefone", usuario.Telefone);
            parameters.Add(":Id", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
            await connection.ExecuteAsync(sql, parameters);
            return parameters.Get<int>("Id");
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            const string sql = "SELECT * FROM TB_USUARIO";

            using var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_connectionString);
            return await connection.QueryAsync<Usuario>(sql);
        }
    }
}
