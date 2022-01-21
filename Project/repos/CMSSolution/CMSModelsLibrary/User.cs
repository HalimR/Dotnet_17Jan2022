using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSModelsLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public int Experience { get; set; }
        public string Speciality { get; set; }

        private string password { get; set; }
        public string Password
        {
            get
            {
                string masked = "XXXXXX" + password.Substring(6, 4);
                return masked;
            }
            set
            {
                password = value;
            }
        }

        public User()
        {
            Type = "Patient"; //by default
        }

        public void TakeDetailsFromUser(User user)
        {
            int tempInt;

            TakeStandardDetail();
            if (user.Type == "Patient")
            {
                Console.WriteLine("Pleae enter Remarks");
                Remarks = Console.ReadLine();
                Console.WriteLine("Pleae enter Status");
                Status = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Pleae enter your Speciality");
                Speciality = Console.ReadLine();

                Console.WriteLine("Pleae enter year of Experience");
                while (!int.TryParse(Console.ReadLine(), out tempInt))
                    Console.WriteLine("Please enter a number (integer) for years of Experience");
                Experience = tempInt;
            }
        }

        public void TakeStandardDetail()
        {
            int tempInt;
            Console.WriteLine("Pleae enter the User ID");
            while (!int.TryParse(Console.ReadLine(), out tempInt))
                Console.WriteLine("Please enter a number (integer) for User ID");
            Id = tempInt;

            Console.WriteLine("Pleae enter the User Name");
            Name = Console.ReadLine();
            Console.WriteLine("Pleae enter the User Password");
            Password = Console.ReadLine();

            Console.WriteLine("Pleae enter the User Age");
            while (!int.TryParse(Console.ReadLine(), out tempInt))
                Console.WriteLine("Please enter a number (integer) for User Age");
            Age = tempInt;
        }

        public virtual void PrintUserDetails()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("User ID: {0} \nUser Name: {1} \nUser Password: {2}  \nUser Age: {3}  \nUser Type: {4}", Id, Name, Password, Age, Type);
            Console.WriteLine("---------------------------------------");
        }

    }
}
