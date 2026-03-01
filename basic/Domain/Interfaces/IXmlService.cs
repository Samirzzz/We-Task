using Application.DTOs;
namespace basic.Domain.Interfaces{
    public interface IXmlService{
        GroupResponseDto ParseGroupResponse(string xml);
    }
}