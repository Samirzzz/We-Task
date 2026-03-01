using basic.Domain.Models;
namespace basic.Domain.Interfaces{
    public interface IGroupRepository
    {
        Groups GetById(int id);
        List<Groups> getGroupsByIds(List<int> ids);
        
    }
}