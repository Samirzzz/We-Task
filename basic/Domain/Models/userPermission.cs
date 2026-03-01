namespace basic.Domain.Models{
    public class userPermission{
        public int id{get;set;}
        public string controller{get;set;}
        public string action{get;set;}
        public int roleId{get;set;}
    }
}