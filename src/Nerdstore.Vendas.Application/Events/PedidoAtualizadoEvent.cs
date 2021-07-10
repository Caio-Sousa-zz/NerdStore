using System;
using NerdStore.Core.Messages;

namespace Nerdstore.Vendas.Application.Events
{
    public class PedidoAtualizadoEvent : Event
    {
        public Guid ClientId { get; }
        public Guid PedidoId { get; }
        public decimal ValorTotal { get; }

        public PedidoAtualizadoEvent(Guid clientId, Guid pedidoId, decimal valorTotal)
        {
            AggregateId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
            ValorTotal = valorTotal;    
        }
    }
}