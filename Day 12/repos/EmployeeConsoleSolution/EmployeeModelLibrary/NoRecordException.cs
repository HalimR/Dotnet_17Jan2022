using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelLibrary
{
    public class NoRecordException : Exception
    {
        string message;
        public NoRecordException()
        {
            message = "No record found. Try again later";
        }
        public override string Message => message;
    }
}
