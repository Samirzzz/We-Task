using Application.DTOs;
using basic.Application.shared;
namespace basic.Domain.Interfaces{
    public interface IXmlService{
        Response<GroupResponseDto> ParseGroupResponse(string xml);
    }
}