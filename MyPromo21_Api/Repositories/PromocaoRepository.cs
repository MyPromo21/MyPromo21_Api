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
        private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=Bruno";
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
                    var query = "insert into Promocao (Token,Id_Produto,Validade_Promo,Id_Estabelecimento,Motivo)" +
                        "values (@token,@id_Produto,@validade_Promo,@id_Estabelecimento,@motivo)";
                    var parameters = new
                    {
                        promocao.Token,
                        promocao.Id_Produto,
                        promocao.Validade_Promo,
                        promocao.Id_Estabelecimento,
                        promocao.Motivo
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
        public bool UpdatePromocao(PromocaoDto promocao)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "update Promocao set Token = @token,Id_Produto = @id_Produto,Validade_Promo = @validade_Promo,Motivo = @motivo where Id = @id";
                    var parameters = new
                    {
                        promocao.Token,
                        promocao.Id_Produto,
                        promocao.Validade_Promo,
                        promocao.Motivo,
                        promocao.Id
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
        public ProdutoDto GetProduto(int id)
        {
            var produto = new ProdutoDto();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Produto where Id = @id";
                    var parameters = new { id };
                    produto = _conexaoBanco.QueryFirstOrDefault<ProdutoDto>(query,parameters);
                }
            }
            catch (SqlException e)
            {
                produto = null;
            }

            return produto;
        }
        public Estabelecimento GetEstabelecimento(int id)
        {
            var estabelecimento = new Estabelecimento();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Estabelecimento where Id = @id";
                    var parameters = new { id };
                    estabelecimento = _conexaoBanco.QueryFirstOrDefault<Estabelecimento>(query,parameters);
                }
            }
            catch (SqlException e)
            {
                estabelecimento = null;
            }

            return estabelecimento;
        }
        public GetAllPromocao CarregarInicio()
        {
            var promocoes = new GetAllPromocao();
     
            promocoes.Promocoes = this.GetAll();
            foreach (PromocaoDto p in promocoes.Promocoes)
            {
                promocoes.Estabelecimentos.Add(this.GetEstabelecimento(p.Id_Estabelecimento));
                promocoes.Produtos.Add(this.GetProduto(p.Id_Produto));
            }
            return promocoes;
        }
    }
}
