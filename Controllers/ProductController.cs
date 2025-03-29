using Microsoft.AspNetCore.Mvc;
using muriel_backend.Models;
using System.Collections.Generic;

namespace MurielBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        // Simulação de dados de produtos
        private static List<Produto> Produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Caderno", Preco = 20.5 },
            new Produto { Id = 2, Nome = "Caneta", Preco = 1.2 }
        };

        // GET: api/produto
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Produtos);
        }

        // GET: api/produto/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = Produtos.Find(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // POST: api/produto
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            Produtos.Add(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }
    }
}
