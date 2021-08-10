using MediatR;
using System;

namespace NerdStore.Core.Messages.CommonMessages.DomainEvents
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; }

        protected DomainEvent(Guid aggregateId)
        {
            Timestamp = DateTime.Now;
            AggregateId = aggregateId;
        }
    }
}