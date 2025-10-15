using Domain.IRepositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MaidoContext _maidoContext;

        public UnitOfWork(
            MaidoContext maidoContext)
        {
            _maidoContext = maidoContext;
        }

        public void Dispose()
        {
            _maidoContext?.Dispose();
        }

        public void SaveChanges()
        {
            _maidoContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _maidoContext.SaveChangesAsync();
        }
    }
}
