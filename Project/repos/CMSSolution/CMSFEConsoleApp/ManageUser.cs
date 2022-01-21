using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSModelsLibrary;

namespace CMSFEConsoleApp
{
    class ManageUser
    { 
        //User user = new User();
        public void RegisterAndDisplayUser()
        {
            Console.WriteLine("Please enter user type (Patient/Doctor)");
            User user;
            string type = Console.ReadLine();
            switch (type)
            {
                case "Patient":
                    user = new Patient();
                    break;
                case "Doctor":
                    user = new Doctor();
                    break;
                default:
                    Console.WriteLine("Invalid Entry. Treating as a patient");
                    user = new Patient();
                    break;
            }
            user.TakeDetailsFromUser(user);
            user.PrintUserDetails();
        }
        //public void DisplayUser(User user)
        //{
        //    user.PrintUserDetails();
        //}
    }
}
