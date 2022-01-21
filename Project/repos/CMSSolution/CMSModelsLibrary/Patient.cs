using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSModelsLibrary
{
    public class Patient : User
    {
        //public string Remarks { get; set; }
        //public string Status { get; set; }

        public Patient()
        {
            Type = "Patient";
        }

        public override void PrintUserDetails()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("User ID: {0} \nUser Name: {1} \nUser Password: {2}  \nUser Age: {3}  \nUser Type: {4}", Id, Name, Password, Age, Type);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Remarks: {0} \nStatus: {1}", Remarks, Status);
            Console.WriteLine("---------------------------------------");
        }
    }
}
