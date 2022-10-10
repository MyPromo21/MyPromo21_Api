using Dapper;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MyPromo21_Api.Repositories
{
    public class EnderecoRepository
    {
        private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=mypromo;Integrated Security=True";
        private SqlConnection _conexao
        {
            get
            {
                return new SqlConnection(_connection);
            }
        }
        public bool CreateEndereco(Endereco endereco)
        {
            try
            {
                var query = @"INSERT INTO Endereco 
                              (IdEstabelecimento, Estado, Cidade, Bairro, Rua, Numero, Complemento, Cep) VALUES (@idEstabelecimento, @estado,@cidade,@bairro,@rua,@numero,@complemento,@cep)";
                using (_conexao)
                {
                    var parameters = new
                    {
                        endereco.IdEstabelecimento,
                        endereco.Estado,
                        endereco.Cidade,
                        endereco.Bairro,
                        endereco.Rua,
                        endereco.Numero,
                        endereco.Complemento,
                        endereco.Cep
                    };

                    _conexao.Query(query, parameters);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public List<EnderecoDto> ReadAllEndereco()
        {
            List<EnderecoDto> enderecosEncontrados;
            try
            {
                var query = @"SELECT * FROM Endereco";

                using (_conexao)
                {
                    enderecosEncontrados = _conexao.Query<EnderecoDto>(query).ToList();
                }

                return enderecosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public bool UpdateEndereco(EnderecoDto endereco)
        {
            try
            {
                var query = @"UPDATE Endereco SET Estado=@estado, Cidade=@cidade, Bairro=@bairro, Rua=@rua, Numero=@numero, Complemento=@complemento, Cep=@cep WHERE Id = @id";
                using (_conexao)
                {
                    var parameters = new
                    {
                        endereco.Id,
                        endereco.Estado,
                        endereco.Cidade,                       
                        endereco.Bairro,                       
                        endereco.Rua,                       
                        endereco.Numero,                       
                        endereco.Complemento,                       
                        endereco.Cep             
                             
                    };

                    _conexao.Query(query, parameters);
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public bool DeleteEndereco(int id)
        {
            try
            {
                var query = "DELETE FROM Endereco " +
                    "WHERE Id= @id";

                using (_conexao)
                {
                    var parameters = new
                    {
                        id
                    };

                    _conexao.Query(query, parameters);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
