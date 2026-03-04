using System.Xml.Linq;
using basic.Application.DTOs;
using basic.Domain.Interfaces;
using basic.Application.shared;
using static basic.Application.Services.ConsumptionService;
using System;
namespace basic.Application.Services{
    public class AvtService : IAvtService{
      public Response<List<FbbDto>> GetFbb(string xml)
        {
            var doc = XDocument.Parse(xml);

            var rows = doc.Descendants("Row").ToList();
            var fbb = new List<FbbDto>();

            foreach (var row in rows)
            {
                var dto = new FbbDto
                {
                    SUBS_ID = row.Descendants("Cell")
                        .Where(cell => DecodeBase64(cell.Attribute("column")?.Value) == "i:SUBS_ID")
                        .Select(cell => DecodeBase64(cell.Value ?? throw new Exception("Value not found")))
                        .FirstOrDefault() ?? throw new Exception("SUBS_ID not found"),

                    Avg_Handling_Time_Hours_Logical =
                        string.IsNullOrEmpty(
                            row.Descendants("Cell")
                            .Where(cell => DecodeBase64(cell.Attribute("column")?.Value) == "i:AVG_Handling_Time_Hours_Logical")
                            .Select(cell => DecodeBase64(cell.Value))
                            .FirstOrDefault()
                        )
                        ? null 
                        : double.Parse(
                            row.Descendants("Cell")
                            .Where(cell => DecodeBase64(cell.Attribute("column")?.Value) == "i:AVG_Handling_Time_Hours_Logical")
                            .Select(cell => DecodeBase64(cell.Value))
                            .FirstOrDefault()
                        ),

                    Count_of_Logical_Tickets =
                        string.IsNullOrEmpty(
                            row.Descendants("Cell")
                            .Where(cell => DecodeBase64(cell.Attribute("column")?.Value) == "i:Count_of_Logical_Tickets")
                            .Select(cell => DecodeBase64(cell.Value))
                            .FirstOrDefault()
                        )
                        ? null
                        : int.Parse(
                            row.Descendants("Cell")
                            .Where(cell => DecodeBase64(cell.Attribute("column")?.Value) == "i:Count_of_Logical_Tickets")
                            .Select(cell => DecodeBase64(cell.Value))
                            .FirstOrDefault()
                        ),
                };

                fbb.Add(dto);
            }

            return new Response<List<FbbDto>>("FBB parsed successfully", fbb);
        }

             public Response<List<GsmDto>> GetGsm(string xml){
            var doc=XDocument.Parse(xml);
            var rows=doc.Descendants("Row").ToList();
            var gsm=new List<GsmDto>();
            foreach(var row in rows){
                var dto=new GsmDto{
                SUBS_ID=row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:SUBS_ID").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()??throw new Exception("SUBS_ID not found"),
                
                Avg_Handling_Time_Hours_Complaint=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Complaint").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:double.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Complaint").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
    
   
                Avg_Handling_Time_Hours_Outbound=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Outbound").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:double.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Outbound").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
    
                Avg_Handling_Time_Hours_Problem=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Problem").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:double.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Problem").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
    
    Avg_Handling_Time_Hours_Request=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Request").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:double.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Request").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
    
                Avg_Handling_Time_Hours_Voice_of_Customer=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Voice_of_Customer").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:double.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Avg_Handling_Time_Hours_Voice_of_Customer").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
    
    Count_of_Complaint_Tickets=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Count_of_Complaint_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:int.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Count_of_Complaint_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
    
                Count_of_Outbound_Tickets=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Count_of_Outbound_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:int.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Count_of_Outbound_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
    
                Count_of_Problem_Tickets=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Count_of_Problem_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:int.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Count_of_Problem_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
                Count_of_Voice_of_Customer_Tickets=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Count_of_Voice_of_Customer_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:int.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Count_of_Voice_of_Customer_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
    
                Most_Frequent_Problem_Complaint=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Complaint").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Complaint").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault(),
    
                Most_Frequent_Problem_Outbound=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Outbound").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Outbound").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault(),
    
                Most_Frequent_Problem_Problem=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Problem").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Problem").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault(),
    
                    Most_Frequent_Problem_Request=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Request").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Request").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault(),
    
                Most_Frequent_Problem_Voice_of_Customer=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Voice_of_Customer").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Most_Frequent_Problem_Voice_of_Customer").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault(),
    
                Total_Count_of_Tickets=String.IsNullOrEmpty(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Total_Count_of_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault())?null:int.Parse(row.Descendants("Cell").Where(cell=>DecodeBase64(cell.Attribute("column")?.Value)=="i:Total_Count_of_Tickets").Select(cell=>DecodeBase64(cell.Value)).FirstOrDefault()),
            };
            gsm.Add(dto);
        }
        return new Response<List<GsmDto>>(message: "Gsm parsed successfully", data: gsm);
    }
}
}