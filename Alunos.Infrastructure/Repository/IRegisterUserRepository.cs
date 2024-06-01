using Alunos.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alunos.Infrastructure.Repository
{
    public interface IRegisterUserRepository
    {
        Task WriteUsers(string password, string name, string user);
        Task<List<StudentsDTO>> RedUsers();
        Task DeleteUser(int id);
        Task UpdateUsers(int id, string nome, string usuario);
    }
}
