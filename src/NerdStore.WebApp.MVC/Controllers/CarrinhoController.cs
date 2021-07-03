using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using Nerdstore.Vendas.Application.Commands;
using ControllerBase = NerdStore.WebApp.MVC.Controllers.Base.ControllerBase;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _protudtoAppService;
        private readonly IMediatorHandler _mediatorHandler;

        public CarrinhoController(INotificationHandler<DomainNotification> notification,
                                  IProdutoAppService protudtoAppService,
                                  IMediatorHandler mediatorHandler) : base(notification, mediatorHandler)
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
            
            if (OperacaoValida())
            {
                return RedirectToAction("Index");
            }

            TempData["Erros"] = ObterMensagemErro();

            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }
    }
}