using basic.Application.shared;
using basic.Application.DTOs;
using System.Collections.Generic;
namespace basic.Domain.Interfaces{
    public interface IConsumptionService{
        Response <List<ConsumptionDto>> ParseConsumption(string xml);
    }
}