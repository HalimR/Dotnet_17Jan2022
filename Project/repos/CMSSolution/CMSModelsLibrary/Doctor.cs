using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSModelsLibrary
{
    public class Doctor : User
    {
        //public string Experience { get; set; }
        //public string Speciality { get; set; }

        public Doctor()
        {
            Type = "Doctor";
        }
        public override void PrintUserDetails()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("User ID: {0} \nUser Name: {1} \nUser Password: {2}  \nUser Age: {3}  \nUser Type: {4}", Id, Name, Password, Age, Type);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Years of Experience: {0} \nSpeciality: {1}", Experience, Speciality);
            Console.WriteLine("---------------------------------------");
        }
    }

}
