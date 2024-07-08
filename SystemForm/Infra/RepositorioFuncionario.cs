using SystemForm.Entidades;
using SystemForm.ModeloInterface;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SystemForm.Infra.Data.Sql.Repository//DAL
{
    public class RepositorioFuncionario : RepositorioBaseConexaoDados, ICadastroFuncionario
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
                        dbo.TREINAMENTO
                    WHERE 
                        Id = @Id
                ";

                var command = new SqlCommand(consulta, connection);
                command.Parameters.AddWithValue("@Id", Id);

                connection.Open();
                var dataReader = command.ExecuteReader();

                Funcionario funcionario = null;
                if (dataReader.Read())
                {
                    int.TryParse(dataReader["Id"].ToString(), out int id);
                    decimal.TryParse(dataReader["Salario"].ToString(), out decimal salario);
                    DateTime.TryParse(dataReader["DataCadastro"].ToString(), out DateTime dataCadastro);
                    DateTime.TryParse(dataReader["DataAtualizacao"].ToString(), out DateTime dataAtualizacao);


                    funcionario = new Funcionario()
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
                }
                connection.Close();
                return funcionario;
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
                      FROM [Funcionario]
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
        public bool Inserir(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(connectionString))
            {//Mudar a consulta para add insert into
                string comandoInserir =

                 $@"
                    INSERT INTO [Funcionario]
                          (
                                  Nome
                                 ,Email
                                 ,Salario
                                 ,Sexo
                                 ,TipoContrato
                                 ,DataCadastro
                             
                           )
                    VALUES
                           (
                                 @Nome,
                                 @Email,
                                 @Salario,
                                 @Sexo,
                                 @TipoContrato,
                                 @DataCadastro

                           )
               
                ";

                var command = new SqlCommand(comandoInserir, connection);

                command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                command.Parameters.AddWithValue("@Email", funcionario.Email);
                command.Parameters.AddWithValue("@Salario", funcionario.Salario);
                command.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                command.Parameters.AddWithValue("@TipoContrato", funcionario.TipoContrato);
                command.Parameters.AddWithValue("@DataCadastro", DateTime.UtcNow);

                connection.Open();

                int resultado = command.ExecuteNonQuery();

                connection.Close();

                return resultado > 0;


            }
        }

        public bool Excluir(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(connectionString))
            {//Mudar a consulta para deletar dado
                string comandoDeletar =

                 $@"
                    DELETE FROM Funcionario
                         
                    WHERE 
                        Id = @Id               
                ";

                var command = new SqlCommand(comandoDeletar, connection);
                command.Parameters.AddWithValue("@Id", Id);

                connection.Open();
                var dataReader = command.ExecuteReader();

                //Funcionario funcionario = null;
                //if (dataReader.Read())
                //{
                //    int.TryParse(dataReader["Id"].ToString(), out int id);
                //    decimal.TryParse(dataReader["Salario"].ToString(), out decimal salario);
                //    DateTime.TryParse(dataReader["DataCadastro"].ToString(), out DateTime dataCadastro);
                //    DateTime.TryParse(dataReader["DataAtualizacao"].ToString(), out DateTime dataAtualizacao);


                //    funcionario = new Funcionario()
                //    {
                //        Id = id,
                //        Nome = dataReader["Nome"].ToString(),
                //        Email = dataReader["Email"].ToString(),
                //        Salario = salario,
                //        Sexo = dataReader["Sexo"].ToString(),
                //        TipoContrato = dataReader["TipoContrato"].ToString(),
                //        DataCadastro = dataCadastro,
                //        DataAtualizacao = dataAtualizacao,
                //    };
                //}
                //connection.Close();
                //return funcionario;
            }

        }
    }
}