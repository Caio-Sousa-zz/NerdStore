﻿using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;

namespace EventSourcing
{
    public class EventStoreService : IEventStoreService
    {
        private readonly IEventStoreConnection _connection;

        public IEventStoreConnection GetConnection() => _connection;

        public EventStoreService(IConfiguration configuration)
        {
            _connection = EventStoreConnection.Create(
                configuration.GetConnectionString("EventStoreConnection"));

            _connection.ConnectAsync();
        }
    }
}