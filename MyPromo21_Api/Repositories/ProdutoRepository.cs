using Dapper;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using MyPromo21_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static MyPromo21_Api.ViewModels.ProdutoViewModel;

namespace MyPromo21_Api.Repositories
{
    public class ProdutoRepository
    {
        private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=ITELABD03\SQLEXPRESS01";
        //private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=Bruno";
        private SqlConnection _conexaoBanco
        {
            get
            {
                return new SqlConnection(_connection);
            }
        }

        public bool CreateProduto(Produto produto)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "insert into Produto(Descricao,Preco,Quantidade,Perecivel,ValidadeProduto,LinkImagem) " +
                        "Values(@descricao,@preco,@quantidade,@perecivel,@validadeProduto,@linkImagem)";
                    var parameters = new
                    {
                        produto.Descricao,
                        produto.Preco,
                        produto.Quantidade,
                        produto.Perecivel,
                        produto.ValidadeProduto,
                        produto.LinkImagem
                    };
                    _conexaoBanco.Query(query, parameters);
                    result = true;
                }
            }
            catch (SqlException e)
            {
                result = false;
            }

            return result;
        }
        public bool UpdateProduto(ProdutoDto produto)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "update Produto set Descricao = @descricao,Preco = @preco,Quantidade = @quantidade,Perecivel = @perecivel,ValidadeProduto = @validadeProduto," +
                        "LinkImagem = @linkImagem where Id = @id";
                    var parameters = new
                    {
                        produto.Descricao,
                        produto.Preco,
                        produto.Quantidade,
                        produto.Perecivel,
                        produto.ValidadeProduto,
                        produto.Id
                    };
                    _conexaoBanco.Query(query,parameters);
                    result = true;
                }
            }
            catch (SqlException e)
            {
                result = false;
            }

            return result;
        }
        public Produto GetProduto(string descricao)
        {
            var produto = new Produto();

            try
            {
                var query = "select * from Produto where Descricao = @descricao";
                var parameters = new
                {
                    descricao
                };

                produto = _conexaoBanco.QueryFirstOrDefault(query,parameters);
            }
            catch (SqlException e)
            {
                produto = null;
            }
            return produto;
        }
        public bool DeleteProduto(ProdutoDeleteViewModel IdProduto)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "delete from Produto where IdProduto = @IdProduto";
                    var parameters = new { IdProduto.IdProduto };
                    _conexaoBanco.Query(query,parameters);
                    result = true;
                }
            }
            catch (SqlException e)
            {
                result = false;
            }

            return result;
        }

    }
}
