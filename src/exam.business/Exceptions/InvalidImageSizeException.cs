using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.business.Exceptions
{
    public class InvalidImageSizeException:Exception
    {
        public string Propertyname { get; set; }
        public InvalidImageSizeException()
        {

        }
        public InvalidImageSizeException(string? message, string propertyname) : base(message)
        {
            Propertyname = propertyname;
        }
    }
}
