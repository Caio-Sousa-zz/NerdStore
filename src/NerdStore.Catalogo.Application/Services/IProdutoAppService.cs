using NerdStore.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Interface
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<IEnumerable<CategoriaViewModel>> ObterCategorias();

        Task AdicionarProduto(ProdutoViewModel ProdutoDto);
        Task AtualizarProduto(ProdutoViewModel ProdutoDto);

        Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade);
    }
}