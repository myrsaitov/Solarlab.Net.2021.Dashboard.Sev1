﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQSubscriber : IDisposable
    {
        void Subscribe(Func<string, IDictionary<string, object>, Task<bool>> callback);
    }
}