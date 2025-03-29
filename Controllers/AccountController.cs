using Microsoft.AspNetCore.Mvc;
using muriel_backend.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


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
    

    //POST: api/account/register
    [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                return BadRequest("Usuário já existe.");
            }

            var user = new User
            {
                Nome = model.Nome,
                Email = model.Email,
                SenhaHash = HashSenha(model.Senha),
                Telefone = model.Telefone,
                DataCadastro = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuário registrado com sucesso." });
        }

        //Método para gerar o hash da senha
        private string HashSenha(string senha)
        {
            return BCrypt.Net.Bcrypt.HashPassword(senha);
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
