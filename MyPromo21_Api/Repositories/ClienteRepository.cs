﻿using Dapper;
using MyPromo21_Api.Dtos;
using MyPromo21_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static MyPromo21_Api.ViewModels.ClienteViewModel;

namespace MyPromo21_Api.Repositories
{
    public class ClienteRepository
    {
        //Conexão Luiz
        private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=mypromo;Integrated Security=True";

        //Conexão Bruno
        //private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=ITELABD03\SQLEXPRESS01";
        //private readonly string _connection = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyPromo21;Data Source=Bruno";
        private SqlConnection _conexaoBanco
        {
            get
            {
                return new SqlConnection(_connection);
            }
        }

        public bool CreateCliente(Cliente cliente)
        {
            var retorno = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "insert into Cliente (IdUsuario, Nome, Cpf, DataNascimento, Telefone, Email, DataCadastro)" +
                        "values (@idUsuario, @nome, @cpf, @dataNascimento, @telefone, @email, @dataCadastro)";
                    var parameters = new
                    {
                        cliente.IdUsuario,
                        cliente.Nome,
                        cliente.Cpf,
                        cliente.DataNascimento,
                        cliente.Telefone,
                        cliente.Email,
                        cliente.DataCadastro
                    };

                    _conexaoBanco.Query(query, parameters);
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
                    var query = "update Cliente set Nome = @nome,Cpf = @cpf,DataNascimento = @dataNascimento,Telefone" +
                        " = @telefone,Email = @email,DataCadastro = @dataCadastro where IdCliente = @idCliente";
                    var parameters = new
                    {
                        cliente.Nome,
                        cliente.Cpf,
                        cliente.DataNascimento,
                        cliente.Telefone,
                        cliente.Email,
                        cliente.DataCadastro,
                        cliente.IdCliente
                    };
                    _conexaoBanco.Query(query, parameters);
                    retorno = true;
                }
            }
            catch (SqlException e)
            {
                retorno = false;
            }

            return retorno;
        }
        public Cliente GetCliente(string cpf)
        {
            var cliente = new Cliente();

            try
            {
                using (_conexaoBanco)
                {
                    var query = "select * from Cliente where Cpf = @cpf";
                    var parameters = new { cpf };
                    cliente = _conexaoBanco.QueryFirstOrDefault<Cliente>(query, parameters);
                }
            }
            catch (SqlException e)
            {
                cliente = null;
            }

            return cliente;
        }
        public bool DeleteCliente(DeleteClienteViewModel deleteClienteViewModel)
        {
            var result = false;

            try
            {
                using (_conexaoBanco)
                {
                    var query = "delete from Cliente where IdCliente = @idCliente";
                    var parameters = new { deleteClienteViewModel.IdCliente };
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
    }
}
