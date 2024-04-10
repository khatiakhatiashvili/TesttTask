using Microsoft.EntityFrameworkCore;
using TestTask.Core.Application.Interfaces;
using TestTask.Core.Domain.Entities;

namespace TestTask.Infrastructure.Persistence.Implementations.Repository
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public async Task<bool> IfExistUser(Guid userId)
        {
           return await _context.Users.AnyAsync(z=>z.Id == userId);
        }
    }
}
