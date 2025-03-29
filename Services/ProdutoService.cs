using muriel_backend.Models;
using muriel_backend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace muriel_backend.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // Método para criar um novo produto
        public async Task<Produto> CreateProdutoAsync(string nome, double preco)
        {
            var produto = new Produto
            {
                Nome = nome,
                Preco = preco
            };

            return await _produtoRepository.CreateProdutoAsync(produto);
        }

        // Método para buscar todos os produtos
        public async Task<List<Produto>> GetAllProdutosAsync()
        {
            return await _produtoRepository.GetAllProdutosAsync();
        }

        // Método para buscar um produto pelo ID
        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _produtoRepository.GetProdutoByIdAsync(id);
        }

        // Método para atualizar um produto existente
        public async Task<Produto> UpdateProdutoAsync(int id, string nome, double preco)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            if (produto != null)
            {
                produto.Nome = nome;
                produto.Preco = preco;

                return await _produtoRepository.UpdateProdutoAsync(produto);
            }

            return null;
        }

        // Método para excluir um produto
        public async Task<bool> DeleteProdutoAsync(int id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            if (produto != null)
            {
                await _produtoRepository.DeleteProdutoAsync(id);
                return true;
            }

            return false;
        }
    }
}
