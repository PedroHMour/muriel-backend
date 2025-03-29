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

        // Método para obter todos os produtos
        public async Task<List<Produto>> GetAllProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        // Método para obter um produto pelo ID
        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        // Método para criar um novo produto
        public async Task<Produto> CreateProdutoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        // Método para excluir um produto
        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        // Método para atualizar um produto existente
        public async Task<Produto> UpdateProdutoAsync(Produto produto)
        {
            _context.Produtos.Update(produto); // Marca o produto para atualização
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
            return produto;
        }
    }
}
