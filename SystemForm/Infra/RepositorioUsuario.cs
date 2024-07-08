using SystemForm.Entidades;
using SystemForm.ModeloInterface;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
namespace SystemForm.Infra.Data.Sql.Repository
{
    internal class RepositorioUsuario : RepositorioBaseConexaoDados, IRepositorioUsuario
    {
        public Usuario ObterPeloLogin(string Login)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string consulta =
                 $@"
                    SELECT 
                        Login, 
                        Senha 
                    FROM 
                        dbo.Usuario 
                    WHERE 
                        Login = @Login
                ";

                var command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@Login", Login);

                connection.Open();
                var dataReader = command.ExecuteReader();

                //if para uma linha while quando consulta retorna mais de uma linha
                // como esta buscando por Id e o ID é unico então só existira uma linha
                if (dataReader.Read()) return new Usuario()
                {
                    Login = dataReader["Login"].ToString(),
                    Senha = dataReader["Senha"].ToString(),
                };

                return new Usuario();
            }
        }

        public Usuario ObterPeloLoginSenha(string login, string senha)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string consulta =
                 $@"
                    SELECT 
                        Login, 
                        Senha 
                    FROM 
                        dbo.Usuario 
                    WHERE 
                        Login = @Login AND
                        Senha = @Senha
                ";

                var command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Senha", senha);

                connection.Open();
                var dataReader = command.ExecuteReader();

                //if para uma linha while quando consulta retorna mais de uma linha
                // como esta buscando por Id e o ID é unico então só existira uma linha
                if (dataReader.Read()) return new Usuario()
                {
                    Login = dataReader["Login"].ToString(),
                    Senha = dataReader["Senha"].ToString(),
                };

                return null;
            }
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string consulta =
                 $@"
                    SELECT
                        Login, 
                        Senha 
                    FROM 
                        dbo.Usuario
                ";

                var command = new SqlCommand(consulta, connection);

                connection.Open();
                var dataReader = command.ExecuteReader();

                var usuarios = new List<Usuario>();

                while (dataReader.Read())
                {
                    int.TryParse(dataReader["Id"].ToString(), out int id);

                    var usuario = new Usuario()
                    {
                        Login = dataReader["Login"].ToString(),
                        Senha = dataReader["Senha"].ToString(),
                    };

                    usuarios.Add(usuario);
                }

                return usuarios;
            }
        }


    }
}
