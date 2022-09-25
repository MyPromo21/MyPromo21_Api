﻿using MyPromo21_Api.Models;
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
        private readonly string _connection = @"Data Source=ITELABD12\SQLEXPRESS; Initial Catalog=MyPromo21; Integrated Security=True;";
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
                              (IdUsuario, NomeFantasia, Cnpj, IdEndereco) VALUES (@idUsuario, @nomeFantasia, @cnpj, @idEndereco)";
                using (_conexao)
                {
                    var parameters = new
                    {
                        estabelecimento.IdUsuario,
                        estabelecimento.NomeFantasia,
                        estabelecimento.Cnpj,
                        estabelecimento.IdEndereco
                        
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
                var query = @"SELECT IdUsuario, NomeFantasia, Cnpj, IdEndereco FROM Estabelecimento";

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
    }
}
