using Microsoft.EntityFrameworkCore.Storage;
using TestTask.Core.Application.Interfaces;
using TestTask.Infrastructure.Persistence.Implementations.Repository;

namespace TestTask.Infrastructure.Persistence.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;


        private IUserRepository _userRepository; 

        private IMovieRepository _movieRepository;
        public IWatchListRepository _watchListRepository;

        private readonly DataContext _context;
        public UnitOfWork(DataContext context) => this._context = context;

     
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public IMovieRepository MovieRepository => _movieRepository ??= new MovieRepository(_context);
        public IWatchListRepository WatchListRepository => _watchListRepository ??= new WatchListRepository(_context);
        
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if(_transaction != null)
            {
                return;
            }
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }
        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _transaction.CommitAsync(cancellationToken);
            }
            catch {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if( _transaction != null )
                {
                    Dispose();
                }
            }
        }
        public void Dispose()
        {
            _transaction.Dispose();
            _context.Dispose();
            _transaction = null;
        }
        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if(_transaction != null)
            {
                return;
            }
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}
