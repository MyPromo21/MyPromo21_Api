using Dapper;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static MyPromo21_Api.ViewModels.PromocaoViewModel;

namespace MyPromo21_Api.Repositories
{
    public class PromocaoRepository
    {
        //private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=mypromo;Integrated Security=True";
        // private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=" + Environment.MachineName;

        private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=mypromo;Integrated Security=True";

        private SqlConnection _conexaoBanco
        {
            get
            {
                return new SqlConnection(_connection);
            }
        }
        public bool CreatePromocao(Promocao promocao)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "insert into Promocao (Token,ValidadePromo,Motivo,IdEndereco,IdEstabelecimento,Desconto)" +
                        "values (@token,@validadePromo,@motivo,@idEndereco,@idEstabelecimento,@desconto)";
                    var parameters = new
                    {
                        promocao.Token,

                        promocao.ValidadePromo,
                        
                        promocao.Motivo,

                        promocao.IdEndereco,
                        promocao.IdEstabelecimento,
                        promocao.Desconto
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
        //public bool UpdatePromocao(PromocaoDto promocao)
        //{
        //    var result = false;

        //    try
        //    {
        //        using (_conexaoBanco)
        //        {
        //            var query = "update Promocao set Token = @token,Id_Produto = @id_Produto,Validade_Promo = @validade_Promo,Motivo = @motivo where Id = @id";
        //            var parameters = new
        //            {
        //                promocao.Token,
        //                promocao.IdProduto,
        //                promocao.Validade_Promo,
        //                promocao.Motivo,
        //                promocao.Id
        //            };
        //            _conexaoBanco.Query(query,parameters);
        //            result = true;
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        result = false;
        //    }

        //    return result;
        //}
        public bool DeletePromocao(DeletePromocaoViewModel deletePromocaoViewModel)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "delete from Promocao where Id = @id";
                    var parameters = new { deletePromocaoViewModel.Id_Promocao };
                    _conexaoBanco.Query(query,parameters);
                    result = true;
                };
            }
            catch (SqlException e)
            {
                result = false;
            }

            return result;
        }
        public List<PromocaoDto> GetAll()
        {
            var promocoes = new List<PromocaoDto>();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Promocao";
                    promocoes = _conexaoBanco.Query<PromocaoDto>(query).ToList();
                }
            }
            catch (SqlException e)
            {
                promocoes = null;
            }

            return promocoes;
        }
        //public ProdutoDto GetProduto(int id)
        //{
        //    var produto = new ProdutoDto();

        //    try
        //    {
        //        using (_conexaoBanco)
        //        {
        //            var query = "select * from Produto where Id = @id";
        //            var parameters = new { id };
        //            produto = _conexaoBanco.QueryFirstOrDefault<ProdutoDto>(query,parameters);
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        produto = null;
        //    }

        //    return produto;
        //}
        //public Estabelecimento GetEstabelecimento(int id)
        //{
        //    var estabelecimento = new Estabelecimento();

        //    try
        //    {
        //        using (_conexaoBanco)
        //        {
        //            var query = "select * from Estabelecimento where Id = @id";
        //            var parameters = new { id };
        //            estabelecimento = _conexaoBanco.QueryFirstOrDefault<Estabelecimento>(query,parameters);
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        estabelecimento = null;
        //    }

        //    return estabelecimento;
        //}
        public List<PromocaoDto> CarregarInicio()
        {
            var promocoes = new List<PromocaoDto>();
            var validadePromo = DateTime.Now.ToString();
            try
            {
                using (_conexaoBanco)
                {
                    var parameters = new { validadePromo };
                    var query = "select * from promocao where ValidadePromo > @validadePromo";
                    promocoes = _conexaoBanco.Query<PromocaoDto>(query,parameters).ToList();
                }
            }
            catch (SqlException e)
            {
                promocoes = null;
            }
            return promocoes;
        }

        public PromocaoDto BuscarPorID(int id)
        {
            PromocaoDto promocaoEncontrada;
            try
            {
                var query = @$"SELECT * FROM Promocao where Id = {id} ";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    promocaoEncontrada = connection.QueryFirstOrDefault<PromocaoDto>(query, parametros);
                }
                return promocaoEncontrada;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }


        public List<PromocaoDto> BuscarPorToken(string token)
        {
            List<PromocaoDto> PromocoesEncontrados;
            try
            {
                var query = @$"SELECT * FROM Promocao where Login LIKE '%{token}%' ";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    PromocoesEncontrados = connection.Query<PromocaoDto>(query).ToList();

                }

                return PromocoesEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public List<PromocaoDto> GetByDesconto(int desconto)
        {
            var promocoes = new List<PromocaoDto>();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Promocao where Desconto <= @desconto";
                    var parameters = new { desconto };
                    promocoes = _conexaoBanco.Query<PromocaoDto>(query,parameters).ToList();
                }
            }
            catch (SqlException e)
            {
                promocoes = null;
            }

            return promocoes;
        }


        public List<PromocaoDto> PromocaoPorIdRetornandoLista(int id)
        {
            var promocoes = new List<PromocaoDto>();

            try
            {
                using (_conexaoBanco)
                {
                    var query = @$"SELECT * FROM promocao where IdEstabelecimento = {id} ";

                    promocoes = _conexaoBanco.Query<PromocaoDto>(query).ToList();
                }
            }
            catch (SqlException)
            {
                promocoes = null;
            }

            return promocoes;
        }

    }
}
