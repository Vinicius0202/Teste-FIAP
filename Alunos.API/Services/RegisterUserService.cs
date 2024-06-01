using Alunos.API.Interfaces;
using Alunos.Domain.Entidades;
using Alunos.Infrastructure.Repository;

namespace Alunos.API.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private IRegisterUserRepository _repo;

        public RegisterUserService(IRegisterUserRepository repo) { _repo = repo; }

        public async Task DeleteUser(int id)
        {
            try
            {
                if (id > 0)
                {
                    await _repo.DeleteUser(id);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<StudentsDTO>> RedUsers()
        {
            try
            {
                return await _repo.RedUsers();
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
                if (id > 0)
                {
                    await _repo.UpdateUsers(id, nome, usuario);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task WriteUsers(string password, string name, string user)
        {
            try
            {
                if (!string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(user))
                {
                    await _repo.WriteUsers(password, name, user);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}