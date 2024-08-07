﻿using System;
namespace CommonLibrary.Interfaces.Services
{
    public interface IRequestsService
    {
        Task SendRequestAsync<T>(string path, T argument);
        Task<V> SendRequestAsync<V, T>(string path, T argument);
    }
}