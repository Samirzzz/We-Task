using basic.Domain.Interfaces;
using basic.Application.DTOs;
using basic.Application.shared;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System;
namespace basic.Application.Services{
public class ConsumptionService :IConsumptionService{

public Response <List<ConsumptionDto>> ParseConsumption(string xml){
  var doc=XDocument.Parse(xml);

  var rows=doc.Descendants("Row").ToList();
  var consumptions=new List<ConsumptionDto>();
  foreach(var row in rows){
    var dto=new ConsumptionDto{
     ServiceName=row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Service").Select(cell=>DecodeBase64(cell.Value??throw new Exception("Value not found"))).FirstOrDefault()??throw new Exception("ServiceName not found"),
    Subscriber=row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Subscriber").Select(cell=>DecodeBase64(cell.Value??throw new Exception("Value not found"))).FirstOrDefault()??throw new Exception("Subscriber not found"),
    Total=long.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:TOTAL").Select(cell=>DecodeBase64(cell.Value??throw new Exception("Value not found"))).FirstOrDefault()??throw new Exception("Total not found")),
        };
            consumptions.Add(dto);

    }
    return new Response<List<ConsumptionDto>>(message: "Consumption parsed successfully", data: consumptions);
}
public static string DecodeBase64(string? value)
{
    if (string.IsNullOrEmpty(value))
    {
        return string.Empty;
    }
    var bytes = Convert.FromBase64String(value);
    return System.Text.Encoding.UTF8.GetString(bytes);
}
}


}