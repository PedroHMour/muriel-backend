using Microsoft.AspNetCore.Mvc;
using muriel_backend.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using muriel_backend.Data;

namespace muriel_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/account/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Verifica se o e-mail já está registrado no banco
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            {
                return BadRequest(new { error = "Email já em uso." });
            }

            // Cria um novo usuário
            var user = new User
            {
                Nome = model.Nome,
                Email = model.Email,
                SenhaHash = HashSenha(model.Senha),
                Telefone = model.Telefone,
                DataCadastro = DateTime.UtcNow
            };

            // Adiciona o usuário ao banco de dados
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Retorna a resposta de sucesso
            return Ok(new { message = "Usuário registrado com sucesso!" });
        }

        // Método para gerar o hash da senha
        private string HashSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
    }

    // Modelo de dados para o cadastro de usuário
    public class RegisterModel
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
    }
}
