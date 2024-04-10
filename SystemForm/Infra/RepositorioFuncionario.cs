using SystemForm.Entidades;
using SystemForm.ModeloInterface;
using System.Collections.Generic;
using System.Data.SqlClient;
using SystemForm.Infra;
using System;

namespace SystemForm.Infra.Data.Sql.Repository
{
    public class RepositorioFuncionario : RepositorioBase, ICadastroFuncionario
    {
        public Funcionario ObterPeloId(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string consulta =
                 $@"
                    SELECT 
                        Id 
                    FROM 
                        dbo.crud_db 
                    WHERE 
                        Id = @Id
                ";

                var command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@Id", Id);

                connection.Open();
                var dataReader = command.ExecuteReader();

                //if para uma linha while quando consulta retorna mais de uma linha
                // como esta buscando por Id e o ID é unico então só existira uma linha

                if (dataReader.Read())
                {
                    int.TryParse(dataReader["Id"].ToString(), out int id);

                    return new Funcionario()
                    {
                        Id = id,
                    };

                }


                return null;
            }
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string consulta =
                 $@"
                    SELECT [Id]
                          ,[Nome]
                          ,[Email]
                          ,[Salario]
                          ,[Sexo]
                          ,[TipoContrato]
                          ,[DataCadastro]
                          ,[DataAtualizacao]
                      FROM [crud_db].[dbo].[Funcionario]
                ";

                var command = new SqlCommand(consulta, connection);

                connection.Open();
                var dataReader = command.ExecuteReader();

                var funcionarios = new List<Funcionario>();

                while (dataReader.Read())
                {
                    int.TryParse(dataReader["Id"].ToString(), out int id);
                    decimal.TryParse(dataReader["Salario"].ToString(), out decimal salario);
                    DateTime.TryParse(dataReader["DataCadastro"].ToString(), out DateTime dataCadastro);
                    DateTime.TryParse(dataReader["DataAtualizacao"].ToString(), out DateTime dataAtualizacao);
                    

                    var funcionario = new Funcionario()
                    {
                        Id = id,
                        Nome = dataReader["Nome"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        Salario = salario,
                        Sexo = dataReader["Sexo"].ToString(),
                        TipoContrato = dataReader["TipoContrato"].ToString(),
                        DataCadastro = dataCadastro,
                        DataAtualizacao = dataAtualizacao,

                    };

                    funcionarios.Add(funcionario);
                }

                return funcionarios;
            }
        }

    }
}