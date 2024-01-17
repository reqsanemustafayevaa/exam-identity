using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.business.Exceptions
{
    public class NotFoundExceptions:Exception
    {
        public string Propertyname { get; set; }
        public NotFoundExceptions(string? message):base(message)
        {

        }
        public NotFoundExceptions(string?message,string? propertyname):base(message)
        {
            Propertyname = propertyname;
        }
        public NotFoundExceptions()
        {


        }
    }
}
