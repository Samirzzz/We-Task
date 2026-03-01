using System.Collections.Generic;
using System;
namespace Application.DTOs{

public class FreeUnitDetailsDto
    {
        public string FreeUnitInstanceId { get; set; } = "";

        public decimal FreeUnitInitialAmount { get; set; }
        public decimal FreeUnitCurrentAmount { get; set; }

        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public string RollOverFlag { get; set; } = "";
        public DateTime? RollOveredTime { get; set; }

        public FreeUnitOriginDto Origin { get; set; }
        
    }
}