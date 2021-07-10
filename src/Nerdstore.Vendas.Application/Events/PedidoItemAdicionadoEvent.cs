using System;
using NerdStore.Core.Messages;

namespace Nerdstore.Vendas.Application.Events
{
    public class PedidoItemAdicionadoEvent : Event
    {
        public Guid ClientId { get; }
        public Guid PedidoId { get; }
        public Guid ProdutoId { get; }
        public string ProdutoNome { get; }
        public decimal ValorUnitario { get;  }
        public int Quantidade { get; }

        public PedidoItemAdicionadoEvent(Guid clientId, Guid pedidoId, Guid produtoId, string produtoNome, decimal valorUnitario, int quantidade)
        {
            AggregateId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;    
        }
    }
}