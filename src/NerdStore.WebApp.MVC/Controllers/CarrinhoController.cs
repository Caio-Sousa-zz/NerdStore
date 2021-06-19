using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Interface;
using NerdStore.Core.Bus;
using System;
using System.Threading.Tasks;
using Nerdstore.Vendas.Application.Commands;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private IProdutoAppService _protudtoAppService;
        private IMediatorHandler _mediatorHandler;

        public CarrinhoController(IProdutoAppService protudtoAppService,
                                  IMediatorHandler mediatorHandler)
        {
            _protudtoAppService = protudtoAppService;
            _mediatorHandler = mediatorHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _protudtoAppService.ObterPorId(id);

            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";

                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var command = new AdicionarItemPedidoCommand(ClientId, produto.Id, produto.Nome, quantidade, produto.Valor);

            await _mediatorHandler.Enviarcommando(command);

            TempData["Erro"] = "Produto indisponível";

            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });

            return View();
        }
    }
}