namespace basic.Application.shared{
    public class Response<T>{
        public string message{get;set;} = "";
        public T? data{get;set;}
        public Response(string message, T data){
            this.message = message;
            this.data = data;
        }
        

    }
}