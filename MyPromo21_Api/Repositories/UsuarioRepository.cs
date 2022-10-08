using MyPromo21_Api.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPromo21_Api.Dtos;
using Dapper;
using static MyPromo21_Api.ViewModels.UsuarioViewModel;

namespace MyPromo21_Api.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _connection = @"Data Source=ITELABD13\SQLEXPRESS;Initial Catalog=mypromo;Integrated Security=True";
        private SqlConnection _conexao { get
            {
                return new SqlConnection(_connection);
            } }
        public Usuario CreateUsuario(Usuario usuario)
        {
            try
            {
                var query = @"INSERT INTO Usuario 
                              (Login, Senha, Nivel) VALUES (@login,@senha,@nivel)";
                using (_conexao)
                {
                    var parameters = new
                    {
                        usuario.Login,
                        usuario.Senha,
                        usuario.Nivel                       
                    };

                    _conexao.Query(query, parameters);
                    return usuario;
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return usuario;
            }
        }

        public List<UsuarioDto> ReadAllUsuario()
        {
            List<UsuarioDto> usuariosEncontrados;
            try
            {
                var query = @"SELECT Id, Login, Senha, Nivel FROM Usuario";

                using (_conexao)
                {
                    usuariosEncontrados = _conexao.Query<UsuarioDto>(query).ToList();
                }

                return usuariosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public bool UpdateUsuario(UsuarioDto usuario)
        {
            try
            {
                var query = @$"UPDATE Usuario SET Login = @login WHERE Id = @id";

                using (_conexao)
                {
                    var parameters = new
                    {
                        usuario.Login,
                        usuario.Id
                    };

                    _conexao.Query(query,parameters);
                    return true;                    
                }               
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        //public UsuarioDto BuscarPorID(int id)
        //{
        //    var usuario = new UsuarioDto();

        //    try
        //    {
        //        using (_conexao)
        //        {
        //            var query = @$"SELECT * FROM Usuario where Id = {id} ";


        //            var parameters = new { id };

        //            usuario = _conexao.QueryFirstOrDefault(query, parameters);
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        usuario = null;
        //    }

        //    return usuario;
        //}


        public UsuarioDto BuscarPorID(int id)
        {
            UsuarioDto pessoaEncontrada;
            try
            {
                var query = @$"SELECT * FROM Usuario where Id = {id} ";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    pessoaEncontrada = connection.QueryFirstOrDefault<UsuarioDto>(query, parametros);
                }
                return pessoaEncontrada;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }


        public List<UsuarioDto> BuscarPorLogin(string login)
        {
            List<UsuarioDto> usuariosEncontrados;
            try
            {
                var query = @$"SELECT * FROM Usuario where Login LIKE '%{login}%' ";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    usuariosEncontrados = connection.Query<UsuarioDto>(query).ToList();

                }

                return usuariosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }


       

        public bool DeleteUsuario(int id)
        {
            try
            {
                var query = "DELETE FROM Usuario " +
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
