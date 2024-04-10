namespace TestTask.Core.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

        public IMovieRepository MovieRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWatchListRepository WatchListRepository { get; }
        

    }
}
