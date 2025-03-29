using muriel_backend.Models;
using muriel_backend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace muriel_backend.Repositories
{
    public class ProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // M�todo para obter todos os produtos
        public async Task<List<Produto>> GetAllProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        // M�todo para obter um produto pelo ID
        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        // M�todo para criar um novo produto
        public async Task<Produto> CreateProdutoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        // M�todo para excluir um produto
        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        // M�todo para atualizar um produto existente
        public async Task<Produto> UpdateProdutoAsync(Produto produto)
        {
            _context.Produtos.Update(produto); // Marca o produto para atualiza��o
            await _context.SaveChangesAsync(); // Salva as mudan�as no banco de dados
            return produto;
        }
    }
}
