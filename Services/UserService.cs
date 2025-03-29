using muriel_backend.Models;
using muriel_backend.Repositories;
using System;
using System.Threading.Tasks;

namespace muriel_backend.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // M�todo para registrar um novo usu�rio
        public async Task<User> RegisterUserAsync(string nome, string email, string senha, string telefone)
        {
            var user = new User
            {
                Nome = nome,
                Email = email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha), // Criptografa a senha
                Telefone = telefone,
                DataCadastro = DateTime.Now
            };

            return await _userRepository.CreateUserAsync(user);
        }

        // M�todo para obter um usu�rio por ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        // M�todo para obter um usu�rio por email (para login, por exemplo)
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        // M�todo para atualizar um usu�rio
        public async Task<User> UpdateUserAsync(int id, string nome, string email, string telefone)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                user.Nome = nome;
                user.Email = email;
                user.Telefone = telefone;

                return await _userRepository.UpdateUserAsync(user);
            }

            return null;
        }

        // M�todo para excluir um usu�rio
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteUserAsync(id);
                return true;
            }

            return false;
        }
    }
}
