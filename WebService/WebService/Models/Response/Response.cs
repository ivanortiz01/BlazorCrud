using System.Collections.Generic;

namespace WebService.Models.Response
{
    public class Response<T>
    {
        public int success { get; set; }

        public string message { get; set; }

        public T data { get; set; }

        public Response()
        {
            this.success = 0;
        }
    }
}
