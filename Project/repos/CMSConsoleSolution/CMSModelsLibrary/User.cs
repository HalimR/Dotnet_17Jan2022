using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSModelsLibrary;

namespace CMSModelsLibrary
{
    
    public class User
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public int User_Type { get; set; }
        //1 - Patient, 2 - Doctor

        public User()
        {

        }

        public void UserLogin()
        {
            Console.WriteLine("Please enter User ID");
            User_Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter User Password");
            User_Password = Console.ReadLine();
        }

        public void PrintUserDetail(User user)
        {
            Console.WriteLine("**************************");
            Console.WriteLine(user);
            Console.WriteLine("**************************");
        }

        public override string ToString()
        {
            return "User ID: " + User_Id
                + "\nUser Name: " + User_Name
                + "\nUser Password: " + User_Password
                + "\nUser Type: " + (User_Type == 1 ? "Patient" : "Doctor");
        }
    }
}
