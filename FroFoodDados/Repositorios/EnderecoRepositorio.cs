using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using FroFoodDados.ContextoDeDados;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
            catch (Exception e)
            {
                var b = e;
            }
            finally
            {
                connection.Close();
            }
            
            return entity;

        }

        public Endereco Autalizar(Endereco entity)
        {
            var connectionString = "Server = (localdb)\\mssqllocaldb; Database = FroFoodProject; Trusted_Connection = True; MultipleActiveResultSets = true";
            using var connection = new SqlConnection(connectionString);
            var sp = "AtualizarEndereco";
            var sqlCommand = new SqlCommand(sp, connection);
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

        public bool Excluir(Guid id)
        {
            var connectionString = "Server = (localdb)\\mssqllocaldb; Database = FroFoodProject; Trusted_Connection = True; MultipleActiveResultSets = true";
            using var connection = new SqlConnection(connectionString);
            var sp = "ExcluirEndereco";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", id);
            try
            {
                connection.Open();
                var r = sqlCommand.BeginExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public IEnumerable<Endereco> ListarEnderecos(Guid userId)
        {
            var enderecos = new List<Endereco>();

            var connectionString = "Server = (localdb)\\mssqllocaldb; Database = FroFoodProject; Trusted_Connection = True; MultipleActiveResultSets = true";
            using var connection = new SqlConnection(connectionString);
            var sp = "ListarEndereco";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", userId);

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var produto = new Endereco
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Rua = reader["Rua"].ToString(),
                        Bairro = reader["Bairro"].ToString(),
                        Cidade = reader["Cidade"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        Numero = reader["Numero"].ToString(),
                    };

                    enderecos.Add(produto);
                }
            }
            finally
            {
                connection.Close();
            }

            return enderecos;
        }


    }
}
