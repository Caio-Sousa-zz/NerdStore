using System;
using NerdStore.Core.Messages;

namespace Nerdstore.Vendas.Application.Events
{
    public class PedidoRascunhoIniciadoEvent: Event
    {
        public Guid ClientId { get; private set; }

        public Guid PedidoId { get; private set; }

        public PedidoRascunhoIniciadoEvent(Guid clienteId, Guid pedidoId)
        {
            ClientId = clienteId;
            PedidoId = pedidoId;
        }
    }
}