using basic.Application.DTOs;
using basic.Application.shared;
using System.Collections.Generic;

namespace basic.Domain.Interfaces{
    public interface IAvtService{
        Response<List<FbbDto>> GetFbb(string xml);
         Response<List<GsmDto>> GetGsm(string xml);
    }
}