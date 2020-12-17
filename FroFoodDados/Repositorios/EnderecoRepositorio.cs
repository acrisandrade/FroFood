using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace FroFoodDados.Repositorios
{
    public class EnderecoRepositorio : RepositorioBase<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }

        public Endereco Adicionar(Endereco entity)
        {
            var connectionString = "Server = (localdb)\\mssqllocaldb; Database = FroFoodProject; Trusted_Connection = True; MultipleActiveResultSets = true";
            using var connection = new SqlConnection(connectionString);
            var sp = "AdicionarEndereco";
            var sqlCommand = new SqlCommand(sp, connection);
            entity.Id = Guid.NewGuid();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", entity.Id);
            sqlCommand.Parameters.AddWithValue("@Rua", entity.Rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", entity.Bairro);
            sqlCommand.Parameters.AddWithValue("@Cidade", entity.Cidade);
            sqlCommand.Parameters.AddWithValue("@Estado", entity.Estado);
            sqlCommand.Parameters.AddWithValue("@Numero", entity.Numero);
            try
            {
                connection.Open();
                var r = sqlCommand.BeginExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
            return entity;

        }

    }
}
