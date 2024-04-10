using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Application.Commons;
using TestTask.Core.Domain.Entities;

namespace TestTask.Core.Application.Interfaces
{
    public interface IUserRepository : IRepository<Guid, User>
    {      
        Task<bool> IfExistUser(Guid userId);
    }
}
