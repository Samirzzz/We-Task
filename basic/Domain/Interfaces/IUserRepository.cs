using basic.Domain.Models;

namespace basic.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
    }
}
