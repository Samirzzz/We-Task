using System.Collections.Generic;
using System;
namespace Application.DTOs{
public class FreeUnitUsageDto{
        public string FreeUnitName { get; set; } = "";
        public string FreeUnitType { get; set; } = "";
        public int UnitMeasurementId { get; set; }
        public string UnitMeasurementName { get; set; } = "";

        public decimal UnitsInitialNumber { get; set; }
        public decimal UnitsUnUsedAmount { get; set; }

        public List<FreeUnitDetailsDto> Details { get; set; } = new();
}
}