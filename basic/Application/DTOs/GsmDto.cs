namespace basic.Application.DTOs{
    public class GsmDto{
  public string SUBS_ID { get; set; }

        public double? Avg_Handling_Time_Hours_Complaint { get; set; }
        public double? Avg_Handling_Time_Hours_Outbound { get; set; }
        public double? Avg_Handling_Time_Hours_Problem { get; set; }
        public double? Avg_Handling_Time_Hours_Request { get; set; }
        public double? Avg_Handling_Time_Hours_Voice_of_Customer { get; set; }

        public int? Count_of_Complaint_Tickets { get; set; }
        public int? Count_of_Outbound_Tickets { get; set; }
        public int? Count_of_Problem_Tickets { get; set; }
        public int? Count_of_Request_Tickets { get; set; }
        public int? Count_of_Voice_of_Customer_Tickets { get; set; }

        public string Most_Frequent_Problem_Complaint { get; set; }
        public string Most_Frequent_Problem_Outbound { get; set; }
        public string Most_Frequent_Problem_Problem { get; set; }
        public string Most_Frequent_Problem_Request { get; set; }
        public string Most_Frequent_Problem_Voice_of_Customer { get; set; }

        public int? Total_Count_of_Tickets { get; set; }  
    }
}