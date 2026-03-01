using System.Collections.Generic;
using System;
namespace Application.DTOs{
public class GroupResponseDto{
    
    public List<FreeUnitUsageDto> FreeUnitUsages { get; set; } = new();
}
}