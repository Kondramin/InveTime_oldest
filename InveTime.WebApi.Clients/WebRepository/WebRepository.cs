using InveTime.Interfaces.Base.Entity;
using InveTime.Interfaces.Base.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace InveTime.WebApi.Clients.WebRepository
{
    public class WebRepository<T> : IRepository<T> where T : IEntity, new()
    {
        private readonly HttpClient _HttpClient;

        public WebRepository(HttpClient httpClient) => _HttpClient = httpClient;

        
        public bool AutoSaveChanges { get; set; } = true;

        public Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(T item, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<bool> ExistIdAsync(int id, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAfterSkipAsync(int Skip, int Count, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<IPage<T>> GetPageAsync(int PageIndex, int PageSize, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<T> RemoveAsync(T item, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<T> RemoveByIdAsync(int id, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item, CancellationToken Cancel = default)
        {
            //TODO: Realize method!!!
            throw new NotImplementedException();
        }
    }
}
