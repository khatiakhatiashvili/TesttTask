using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Domain.Entities;

namespace TestTask.Core.Application.Interfaces
{
    public interface IWatchListRepository : IRepository<Guid, WatchList>
    {
        Task<bool> IfExistWatchList(Guid userId,Guid movieId);
    }
}
