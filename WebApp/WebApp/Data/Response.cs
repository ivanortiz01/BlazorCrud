using System.Collections.Generic;

namespace WebApp.Data
{
    public class Response<T>
    {
        public int success { get; set; }

        public string message { get; set; }

        public T data { get; set; }
    }
}
