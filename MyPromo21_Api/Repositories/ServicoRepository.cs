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
        //Conexão Bruno
        private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=ITELABD03\SQLEXPRESS01";
        //private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=Bruno";
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
                    var query = "insert into servico (Descricao,Preco,LinkImagem) values (@descricao,@preco,@linkImagem)";
                    var parameters = new
                    {
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
        public bool DeleteServico(DeleteServicoViewModel servico)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "delete from Servico where Id = @id";
                    var parameters = new { servico.Id };
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
    }
}
