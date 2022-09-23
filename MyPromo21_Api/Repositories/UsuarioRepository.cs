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
        private readonly string _connection = @"Data Source=ITELABD12\SQLEXPRESS; Initial Catalog=MyPromo21; Integrated Security=True;";
        public bool CreateUsuario(UsuarioModel usuarioModel)
        {
            try
            {
                var query = @"INSERT INTO UsuarioModel 
                              (Usuario, Senha, Nivel) VALUES (@usuario,@senha,@nivel)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@usuario", usuarioModel.Usuario);
                    command.Parameters.AddWithValue("@senha", usuarioModel.Senha);
                    command.Parameters.AddWithValue("@nivel", usuarioModel.Nivel);                   
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Usuário cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public List<UsuarioDto> ReadAllUsuario()
        {
            List<UsuarioDto> usuariosEncontrados;
            try
            {
                var query = @"SELECT Id, Usuario, Senha, Nivel FROM UsuarioModel";

                using (var connection = new SqlConnection(_connection))
                {
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

        public bool UpdateUsuario(UsuarioDto usuario, int id)
        {
            try
            {
                var query = @"UPDATE UsuarioModel SET Usuario = @usuario, Senha = @senha, Nivel = @nivel WHERE Id = @id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@usuario", usuario.Usuario);
                    command.Parameters.AddWithValue("@senha", usuario.Senha);
                    command.Parameters.AddWithValue("@nivel", usuario.Nivel);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Usuario atualizado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public bool DeleteUsuario(int id)
        {
            try
            {
                var query = "DELETE FROM UsuarioModel " +
                    "WHERE Id= @id";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Usuario removido com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
