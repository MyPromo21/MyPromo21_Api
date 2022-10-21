using MyPromo21_Api.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPromo21_Api.Dtos;
using Dapper;

namespace MyPromo21_Api.Repositories
{
    public class EstabelecimentoRepository
    {

        //Conexão Luiz
        private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=mypromo;Integrated Security=True";



        private SqlConnection _conexao
        {
            get
            {
                return new SqlConnection(_connection);
            }
        }
        public bool CreateEstabelecimento(Estabelecimento estabelecimento)
        {
            try
            {
                var query = @"INSERT INTO Estabelecimento 
                              (IdEstabelecimento, NomeFantasia, Cnpj) VALUES (@idEstabelecimento, @nomeFantasia, @cnpj)";
                using (_conexao)
                {
                    var parameters = new
                    {
                        estabelecimento.IdEstabelecimento,
                        estabelecimento.NomeFantasia,
                        estabelecimento.Cnpj,
                        
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

        public List<EstabelecimentoDto> ReadAllEstabelecimento()
        {
            List<EstabelecimentoDto> estabelecimentosEncontrados;
            try
            {
                var query = @"SELECT * FROM Estabelecimento";

                using (_conexao)
                {
                    estabelecimentosEncontrados = _conexao.Query<EstabelecimentoDto>(query).ToList();
                }

                return estabelecimentosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public bool UpdateEstabelecimento(EstabelecimentoDto estabelecimentoDto)
        {
            try
            {
                var query = @"UPDATE Estabelecimento SET NomeFantasia = @nomeFantasia, Cnpj = @cnpj WHERE Id = @id";
                using (_conexao)
                {
                    var parameters = new
                    {
                        estabelecimentoDto.NomeFantasia,
                        estabelecimentoDto.Cnpj                        
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

        public bool DeleteEstabelecimento(int id)
        {
            try
            {
                var query = "DELETE FROM Estabelecimento " +
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

        public EstabelecimentoDto BuscarPorID(int id)
        {
            EstabelecimentoDto estabelecimentoEncontrado;
            try
            {
                var query = @$"SELECT * FROM Estabelecimento where Id = {id} ";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    estabelecimentoEncontrado = connection.QueryFirstOrDefault<EstabelecimentoDto>(query, parametros);
                }
                return estabelecimentoEncontrado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }


        public List<EstabelecimentoDto> BuscarPorCnpj(string cnpj)
        {
            List<EstabelecimentoDto> EstabelecimentosEncontrados;
            try
            {
                var query = @$"SELECT * FROM Estabelecimento where Login LIKE '%{cnpj}%' ";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    EstabelecimentosEncontrados = connection.Query<EstabelecimentoDto>(query).ToList();

                }

                return EstabelecimentosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

    }
}
