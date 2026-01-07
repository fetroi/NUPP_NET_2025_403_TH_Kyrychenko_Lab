using System.Collections.Concurrent;

namespace Cinema.Common
{
    public class ThreadSafeRepository<T> where T : class
    {
        private readonly ConcurrentDictionary<Guid, T> _store = new();

        public Task AddAsync(Guid id, T entity)
        {
            _store.TryAdd(id, entity);
            return Task.CompletedTask;
        }

        public Task<T?> GetAsync(Guid id)
        {
            _store.TryGetValue(id, out var entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync()
            => Task.FromResult(_store.Values.AsEnumerable());

        public Task<bool> RemoveAsync(Guid id)
            => Task.FromResult(_store.TryRemove(id, out _));

        public Task<bool> UpdateAsync(Guid id, T entity)
        {
            if (!_store.ContainsKey(id)) return Task.FromResult(false);

            _store[id] = entity;
            return Task.FromResult(true);
        }
    }
}
