namespace Cinema.Common
{
    public class CinemaService
    {
        private readonly ThreadSafeRepository<CinemaSession> _repo = new();

        public async Task CreateSessionAsync(CinemaSession session)
            => await _repo.AddAsync(session.Id, session);

        public async Task<CinemaSession?> GetSessionAsync(Guid id)
            => await _repo.GetAsync(id);

        public async Task<IEnumerable<CinemaSession>> GetAllSessionsAsync()
            => await _repo.GetAllAsync();

        public async Task<bool> DeleteSessionAsync(Guid id)
            => await _repo.RemoveAsync(id);

        public async Task<bool> UpdateSessionAsync(Guid id, CinemaSession session)
            => await _repo.UpdateAsync(id, session);
    }
}
