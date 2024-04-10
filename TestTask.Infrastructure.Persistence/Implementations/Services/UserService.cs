using TestTask.Core.Application.Exceptions;
using TestTask.Core.Application.Interfaces;
using TestTask.Core.Application.Services;
using TestTask.Core.Domain.Entities;

namespace TestTask.Infrastructure.Persistence.Implementations.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unit;

        public UserService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<WatchList> CreateWatchListAsync(Guid UserId, Guid MovieId)
        {       
            
              var watchList = new WatchList();
            watchList.UserId = UserId;
            watchList.MovieId = MovieId;
            watchList.DateCreated = DateTime.Now;
                var userExists = await _unit.UserRepository.IfExistUser(UserId);
                if (!userExists)
                {
                throw new EntityNotFoundException("მომხმარებელი არ არსებობს");
                }
            var movieExists = await _unit.MovieRepository.IfExistMovie(MovieId);
            if (!movieExists)
            {
                throw new EntityNotFoundException("ფილმი არ არსებობს");
            }
            var watchListExist = await _unit.WatchListRepository.IfExistWatchList(UserId, MovieId);
            if (watchListExist)
            {
                throw new EntityAlreadyExistsException("ჩანაწერი უკვე არსებობს");
            }
            var newMovieList =   await _unit.WatchListRepository.CreateAsync(watchList);

            return newMovieList;
        }
    }
}
