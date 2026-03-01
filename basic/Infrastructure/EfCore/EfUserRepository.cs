using basic.Domain.Models;
using basic.Domain.Interfaces;
using basic.Infrastructure.Data;
using System.Linq;

namespace basic.Infrastructure.EfCore
{
    public class EfUserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public EfUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.email == email);
        }
    }
}
