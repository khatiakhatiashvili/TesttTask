using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Domain.Entities;

namespace TestTask.Core.Application.Services
{
    public interface IUserService
    {
        Task<WatchList> CreateWatchListAsync(Guid UserId,Guid MovieId);
    }
}
