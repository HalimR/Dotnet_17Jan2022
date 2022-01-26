using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSModelsLibrary;

namespace CMSConsoleApp
{
    public class ManageUser
    {
        List<User> users;

        public ManageUser()
        {
            users = new List<User>();
            users.Add(new User
            {
                User_Id = 101,
                User_Name = "Bob",
                User_Password = "abc123",
                User_Type = 1
            });

            users.Add(new User
            {
                User_Id = 102,
                User_Name = "Sarah",
                User_Password = "abc123",
                User_Type = 2
            });
        }

        public User GetUserById(int id)
        {
            User user = users.Find(p => p.User_Id == id);
            return user;
        }

        public void PrintAllUserDetails()
        {
            var sortedUsers = users.OrderBy(p => p.User_Id);
            foreach (var item in sortedUsers)
            {
                if (item != null)
                    PrintUserDetail(item);
            }
        }

        public void PrintUserDetailById(int id)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                PrintUserDetail(user);
            }
            else
                Console.WriteLine("No such user");
        }

        private void PrintUserDetail(User item)
        {
            Console.WriteLine("**************************");
            Console.WriteLine(item);
            Console.WriteLine("**************************");
        }
    }
}
