using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace Nerdstore.Vendas.Application.Commands
{
    public class AplicarVoucherPedidoCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public string CodigoVoucher { get; private set; }

        public AplicarVoucherPedidoCommand(Guid pedidoId, Guid clienteId, string codigoVoucher)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
            CodigoVoucher = codigoVoucher;  
        }

        public override bool EhValido()
        {
            ValidationResult = new AplicarVoucherPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AplicarVoucherPedidoValidation : AbstractValidator<AplicarVoucherPedidoCommand>
    {
        public AplicarVoucherPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pedido inválido");

            RuleFor(c => c.CodigoVoucher)
                .NotEmpty()
                .WithMessage("O código do voucher não pode ser vazio");
        }
    }
}