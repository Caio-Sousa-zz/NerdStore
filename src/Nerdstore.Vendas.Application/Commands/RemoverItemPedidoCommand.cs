using System;
using FluentValidation;
using NerdStore.Core.Messages;

namespace Nerdstore.Vendas.Application.Commands
{
    public class RemoverItemPedidoCommand : Command
    {
        public Guid ClienteId { get; }
        public Guid PedidoId { get; }
        public Guid ProdutoId { get; }

        public RemoverItemPedidoCommand(Guid clienteId, Guid pedidoId, Guid produtoId)
        {
            ClienteId = clienteId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }

        public override bool EhValido()
        {
            ValidationResult = new RemoverItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoverItemPedidoValidation : AbstractValidator<RemoverItemPedidoCommand>
    {
        public RemoverItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");

            RuleFor(c => c.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pedido inválido");
        }
    }
}