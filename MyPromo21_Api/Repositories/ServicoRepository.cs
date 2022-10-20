using Dapper;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static MyPromo21_Api.ViewModels.ServicoViewModel;

namespace MyPromo21_Api.Repositories
{
    public class ServicoRepository
    {

        private readonly string _connection = @"Data Source=ITELABD13\SQLEXPRESS;Initial Catalog=mypromo;Integrated Security=True";
        private SqlConnection _conexaoBanco
        {
            get
            {
                return new SqlConnection(_connection);
            }
        }

        public bool CreateServico(Servico servico)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "insert into servico (IdPromocao, Descricao,Preco,LinkImagem) values (@idPromocao, @descricao,@preco,@linkImagem)";
                    var parameters = new
                    {
                        servico.IdPromocao,
                        servico.Descricao,
                        servico.Preco,
                        servico.LinkImagem
                    };
                    _conexaoBanco.Query(query,parameters);
                    result = true;
                }
            }
            catch (SqlException)
            {
                result = false;
            }

            return result;
        }
        public bool UpdateServico(ServicoDto servico)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "update servico set Descricao = @descricao,Preco = @preco,LinkImagem = @linkImagem where Id = @id";
                    var parameters = new
                    {
                        servico.Descricao,
                        servico.Preco,
                        servico.LinkImagem,
                        servico.Id
                    };
                    _conexaoBanco.Query(query,parameters);
                    result = true;
                }
            }
            catch (SqlException)
            {
                result = false;
            }

            return result;
        }
        public Servico GetServico(string descricao)
        {
            var servico = new Servico();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Servico where Descricao = @descricao";
                    var parameters = new { descricao };

                    servico = _conexaoBanco.QueryFirstOrDefault(query,parameters);
                }
            }
            catch (SqlException)
            {
                servico = null;
            }

            return servico;
        }
        public bool DeleteServico(int id)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "delete from Servico where Id = @id";
                    var parameters = new { id };
                    _conexaoBanco.Query(query, parameters);
                    result = true;
                };
            }
            catch (SqlException e)
            {
                result = false;
            }

            return result;
        }
        public List<ServicoDto> GetAll()
        {
            var servicos = new List<ServicoDto>();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Servico";
                    servicos = _conexaoBanco.Query<ServicoDto>(query).ToList();
                }
            }
            catch (SqlException)
            {
                servicos = null;
            }

            return servicos;
        }

        public ServicoDto BuscarPorID(int id)
        {
            ServicoDto pessoaEncontrada;
            try
            {
                var query = @$"SELECT * FROM Servico where IdPromocao = {id} ";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    pessoaEncontrada = connection.QueryFirstOrDefault<ServicoDto>(query, parametros);
                }
                return pessoaEncontrada;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }


        public List<ServicoDto> BuscarPorDescricao(string descricao)
        {
            List<ServicoDto> servicosEncontrados;
            try
            {
                var query = @$"SELECT * FROM Servico where Login LIKE '%{descricao}%' ";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    servicosEncontrados = connection.Query<ServicoDto>(query).ToList();

                }

                return servicosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public List<ServicoDto> ServicoPorIdRetornandoLista(int id)
        {
            var servicos = new List<ServicoDto>();

            try
            {
                using (_conexaoBanco)
                {
                    var query = @$"SELECT * FROM Servico where IdPromocao = {id} ";

                    servicos = _conexaoBanco.Query<ServicoDto>(query).ToList();
                }
            }
            catch (SqlException)
            {
                servicos = null;
            }

            return servicos;
        }

    }
}
