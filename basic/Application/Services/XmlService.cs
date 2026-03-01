using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Application.DTOs;
using basic.Domain.Interfaces;
using basic.Application.shared;
namespace basic.Application.Services
{
    public class XmlService : IXmlService
    {
        private static DateTime? ParseDate(string? value) =>
            string.IsNullOrEmpty(value)
                ? null
                : DateTime.ParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

        public Response<GroupResponseDto> ParseGroupResponse(string xml)
        {
            var dto = new GroupResponseDto();

            var doc = XDocument.Parse(xml);
            XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace ns1 = "http://example.com/balance/schema";

            var memberGroup = doc
                .Descendants(ns1 + "MemberGroup")
                .FirstOrDefault() ?? throw new Exception("MemberGroup not found");

            var freeUnitUsageElements = memberGroup
                .Descendants("FreeUnitUsage")
                .ToList();

            if (!freeUnitUsageElements.Any())
            {
                throw new Exception("FreeUnitUsage elements not found");
            }

            foreach (var usage in freeUnitUsageElements)
            {
                var usageDto = new FreeUnitUsageDto
                {
                    FreeUnitName = usage.Descendants("FreeUnitName").FirstOrDefault()?.Value
                                   ?? throw new Exception("FreeUnitName not found"),
                    FreeUnitType = usage.Descendants("FreeUnitType").FirstOrDefault()?.Value
                                   ?? throw new Exception("FreeUnitType not found"),
                    UnitMeasurementId = int.Parse(
                        usage.Descendants("UnitMeasurementId").FirstOrDefault()?.Value
                        ?? throw new Exception("UnitMeasurementId not found")),
                    UnitMeasurementName = usage.Descendants("UnitMeasurementName").FirstOrDefault()?.Value
                                         ?? throw new Exception("UnitMeasurementName not found"),
                    UnitsInitialNumber = decimal.Parse(
                        usage.Descendants("UnitsInitialNumber").FirstOrDefault()?.Value
                        ?? throw new Exception("UnitsInitialNumber not found")),
                    UnitsUnUsedAmount = decimal.Parse(
                        usage.Descendants("UnitsUnUsedAmount").FirstOrDefault()?.Value
                        ?? throw new Exception("UnitsUnUsedAmount not found")),
                    Details = new List<FreeUnitDetailsDto>()
                };


var freeUnitDetailsWrapper=usage.Descendants("FreeUnitDetails").FirstOrDefault()??throw new Exception("FreeUnitDetails not found");
if(freeUnitDetailsWrapper==null){
    throw new Exception("FreeUnitDetails not found");
}
                var freeUnitDetailsElements = freeUnitDetailsWrapper.Descendants("FreeUnitDetails");

                foreach (var detail in freeUnitDetailsElements)
                {
                    var freeUnitDetailDto = new FreeUnitDetailsDto
                    {
                        FreeUnitInstanceId = detail.Descendants("FreeUnitInstanceId").FirstOrDefault()?.Value
                                             ?? throw new Exception("FreeUnitInstanceId not found"),
                        FreeUnitInitialAmount = decimal.Parse(
                            detail.Descendants("FreeUnitInitialAmount").FirstOrDefault()?.Value
                            ?? throw new Exception("FreeUnitInitialAmount not found")),
                        FreeUnitCurrentAmount = decimal.Parse(
                            detail.Descendants("FreeUnitCurrentAmount").FirstOrDefault()?.Value
                            ?? throw new Exception("FreeUnitCurrentAmount not found")),
                        EffectiveDate = ParseDate(
                            detail.Descendants("EffectiveDate").FirstOrDefault()?.Value
                            ?? throw new Exception("EffectiveDate not found")),
                        ExpiryDate = ParseDate(
                            detail.Descendants("ExpiryDate").FirstOrDefault()?.Value
                            ?? throw new Exception("ExpiryDate not found")),
                        RollOverFlag = detail.Descendants("RollOverFlag").FirstOrDefault()?.Value
                                       ?? throw new Exception("RollOverFlag not found")
                    };
                  
                    var freeUnitOrigin = detail.Descendants("FreeUnitOrigin").FirstOrDefault()
                                        ?? throw new Exception("FreeUnitOrigin not found");

                    
                    int? originTypeValue = null;
                    var originTypeElement = freeUnitOrigin.Descendants("FreeUnitOriginType").FirstOrDefault();
                    if (originTypeElement != null)
                    {
                        originTypeValue = int.Parse(originTypeElement.Value);
                    }

                    var offeringKey = freeUnitOrigin.Descendants("OfferingKey").FirstOrDefault();

                    OfferingKeyDto? offeringKeyDto = null;
                    if (offeringKey != null)
                    {
                        offeringKeyDto = new OfferingKeyDto
                        {
                            OfferingId = long.Parse(
                                offeringKey.Descendants("OfferingId").FirstOrDefault()?.Value
                                ?? throw new Exception("OfferingId not found")),
                            PurchaseSeq = offeringKey.Descendants("PurchaseSeq").FirstOrDefault()?.Value
                                          ?? throw new Exception("PurchaseSeq not found")
                        };
                    }

                    var originDto = new FreeUnitOriginDto
                    {
                        FreeUnitOriginType = originTypeValue,
                        OfferingKey = offeringKeyDto
                    };

                    freeUnitDetailDto.Origin = originDto;

                    usageDto.Details.Add(freeUnitDetailDto);
                }

                dto.FreeUnitUsages.Add(usageDto);
            }

            return new Response<GroupResponseDto>(message: "Group response parsed successfully", data: dto);
        }
    }
}
