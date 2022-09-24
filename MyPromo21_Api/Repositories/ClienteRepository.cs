using Dapper;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyPromo21_Api.Repositories
{
    public class ClienteRepository
    {
        private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=ITELABD03\SQLEXPRESS01";
        private SqlConnection _conexaoBanco
        {
            get
            {
                return new SqlConnection(_connection);
            }
        }

        public bool CreateUsuario(ClienteModel cliente)
        {
            var retorno = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "insert into Cliente (Nome,Cpf,Data_Nascimento,Telefone,Email,Data_Cadastro)" +
                        "values (@nome,@cpf,@data_Nascimento,@telefone,@email,@data_Cadastro)";
                    var parameters = new 
                    {
                       cliente.Nome,
                       cliente.Cpf,
                       cliente.Data_Nascimento,
                       cliente.Telefone,
                       cliente.Email,
                       cliente.Data_Cadastro
                    };

                    _conexaoBanco.Query(query,parameters);
                    retorno = true;
                }
            }
            catch (SqlException e)
            {
                retorno = false;
            }

            return retorno;
        }
        public bool UpdateCliente(ClienteDto cliente)
        {
            var retorno = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "update Cliente set Nome = @nome,Cpf = @cpf,Data_Nascimento = @data_Nascimento,Telefone" +
                        " = @telefone,Email = @email,Data_Cadastro = @data_Cadastro where Id_Cliente = @id_Cliente";
                    var parameters = new
                    {
                        cliente.Nome,
                        cliente.Cpf,
                        cliente.Data_Nascimento,
                        cliente.Telefone,
                        cliente.Email,
                        cliente.Data_Cadastro,
                        cliente.Id_Cliente
                    };
                    _conexaoBanco.Query(query,parameters);
                    retorno = true;
                }
            }
            catch (SqlException e)
            {
                retorno = false;
            }

            return retorno;
        }
        public ClienteModel GetCliente(int id_Cliente)
        {
            var cliente = new ClienteModel();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Cliente where Id_Cliente = @id_Cliente";
                    var parameters = new { id_Cliente };
                    cliente = _conexaoBanco.QueryFirstOrDefault<ClienteModel>(query,parameters);
                }
            }
            catch (SqlException e)
            {
                cliente = null;
            }

            return cliente;
        }
    }
}
