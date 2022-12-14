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


        private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=mypromo;Integrated Security=True";


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
                    var query = "insert into Produto(IdPromocao, Descricao,Preco,Quantidade,Perecivel,ValidadeProduto,LinkImagem) " +
                        "Values(@idPromocao, @descricao,@preco,@quantidade,@perecivel,@validadeProduto,@linkImagem)";
                    var parameters = new
                    {
                        produto.IdPromocao,
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
                        produto.LinkImagem,
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
        public ProdutoDto GetProduto(string descricao)
        {
            var produto = new ProdutoDto();

            try
            {
                var query = "select * from Produto where Descricao = @descricao";
                var parameters = new
                {
                    descricao
                };

                produto = _conexaoBanco.QueryFirstOrDefault<ProdutoDto>(query,parameters);
            }
            catch (SqlException e)
            {
                produto = null;
            }
            return produto;
        }
        public bool DeleteProduto(int id)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "delete from produto where Id = @id";
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
        public List<ProdutoDto> GetAll()
        {
            var produtos = new List<ProdutoDto>();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Produto";

                    produtos = _conexaoBanco.Query<ProdutoDto>(query).ToList();
                }
            }
            catch (SqlException)
            {
                produtos = null;
            }

            return produtos;
        }

        public ProdutoDto BuscarPorID(int id)
        {
            ProdutoDto produtoEncontrado;
            try
            {
                var query = @$"SELECT * FROM Produto where IdPromocao = {id} ";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    produtoEncontrado = connection.QueryFirstOrDefault<ProdutoDto>(query, parametros);
                }
                return produtoEncontrado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }


        public List<ProdutoDto> BuscarPorDescricao(string descricao)
        {
            List<ProdutoDto> produtosEncontrados;
            try
            {
                var query = @$"SELECT * FROM Produto where Login LIKE '%{descricao}%' ";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    produtosEncontrados = connection.Query<ProdutoDto>(query).ToList();

                }

                return produtosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public List<ProdutoDto> ProdutoPorIdRetornandoLista(int id)
        {
            var produtos = new List<ProdutoDto>();

            try
            {
                using (_conexaoBanco)
                {
                    var query = @$"SELECT * FROM Produto where IdPromocao = {id} ";

                    produtos = _conexaoBanco.Query<ProdutoDto>(query).ToList();
                }
            }
            catch (SqlException)
            {
                produtos = null;
            }

            return produtos;
        }

        
        public SomaProdutoDto SomaDoValorProdutos(int id)
        {
            SomaProdutoDto SomaValor;
            try
            {
                var query = @$"SELECT SUM(Preco) FROM Produto where IdPromocao = {id} ";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    SomaValor = connection.QueryFirstOrDefault<SomaProdutoDto>(query, parametros);
                }
                return SomaValor;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }



    }
}
