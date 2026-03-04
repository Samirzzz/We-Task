namespace basic.Application.DTOs{
public class FbbDto{
    public string? SUBS_ID { get; set; }

        public double? Avg_Handling_Time_Hours_Logical { get; set; }
        public double? Avg_Handling_Time_Hours_Other { get; set; }
        public double? Avg_Handling_Time_Hours_Physical { get; set; }

        public int? Count_of_Logical_Tickets { get; set; }
        public int? Count_of_Other_Tickets { get; set; }
        public int? Count_of_Physical_Tickets { get; set; }

        public string Most_Frequent_Problem_Logical { get; set; }
        public string Most_Frequent_Problem_Other { get; set; }
        public string Most_Frequent_Problem_Physical { get; set; }

        public int? Total_Count_of_Tickets { get; set; }
    }
}