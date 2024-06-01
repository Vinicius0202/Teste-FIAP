using Alunos.Domain.Entidades;


namespace Alunos.API.Interfaces
{
    public interface IRegisterUserService
    {
        Task WriteUsers(string password, string name, string user);
        Task<List<StudentsDTO>> RedUsers();
        Task DeleteUser(int id);
        Task UpdateUsers(int id, string nome, string usuario);
    }
}
