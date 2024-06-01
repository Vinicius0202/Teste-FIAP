using Alunos.Domain.Entidades;
using Alunos.Infrastructure.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Alunos.Infrastructure.SQL
{
    public class RegisterUserRepository : IRegisterUserRepository
    {

        IConfiguration _config;

        public RegisterUserRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                string connectionString = _config.GetConnectionString("conecction");

                if (string.IsNullOrEmpty(connectionString)) { throw new Exception("Não foi possivel obter a connectionString"); }

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync($"DELETE FROM Aluno WHERE Id = '{id}'");
                }
            }
            catch (Exception e)
            {

                throw new Exception($"Não foi possivel realizar essa operação {e.Message}");
            }
        }

        public async Task<List<StudentsDTO>> RedUsers()
        {
            try
            {
                string connectionString = _config.GetConnectionString("conecction");

                if (string.IsNullOrEmpty(connectionString)) throw new Exception("Não foi possivel obter a connectionString");

                using (var connection = new SqlConnection(connectionString))
                {
                    var students = connection.QueryAsync<StudentsDTO>($"SELECT * FROM Aluno").Result;

                    if (students.Count() > 0)
                    {
                        var Liststudents = new List<StudentsDTO>();

                        foreach (var data in students)
                        {
                            Liststudents.Add(new StudentsDTO
                            {
                                ID = data.ID,
                                Nome = data.Nome,
                                Senha = data.Senha,
                                Usuario = data.Usuario
                            });
                        }

                        return Liststudents;
                    }
                    throw new Exception("Não possui nehum aluno cadastrado");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task UpdateUsers(int id, string nome, string usuario)
        {
            try
            {
                string connectionString = _config.GetConnectionString("conecction");

                if (string.IsNullOrEmpty(connectionString)) { throw new Exception("Não foi possivel obter a connectionString"); }

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync($"UPDATE Aluno SET Nome ='{nome}', Usuario ='{usuario}' WHERE Id ='{id}'");
                }
            }
            catch (Exception e)
            {

                throw new Exception($"Não foi possivel realizar essa operação {e.Message}");
            }
        }

        public async Task WriteUsers(string password, string name, string user)
        {
            try
            {
                string connectionString = _config.GetConnectionString("conecction");

                if (string.IsNullOrEmpty(connectionString)) { throw new Exception("Não foi possivel obter a connectionString"); }

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync($"INSERT INTO Aluno (Nome, Usuario, Senha) VALUES ('{name}','{user}','{password}')");
                }
            }
            catch (Exception e)
            {

                throw new Exception($"Não foi possivel realizar essa operação {e.Message}");
            }
        }
    }
}
