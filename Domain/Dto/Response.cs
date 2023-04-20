using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data, string message = null)
        {
            Succeded = true;
            Menssage = message;
            Result = data;

        }

        public Response(string menssage)
        {
            Succeded = false;
            Menssage = menssage;
        }

        public bool Succeded { get; set; }
        public string Menssage { get; set; }
        public T Result { get; set; }

    }
}
