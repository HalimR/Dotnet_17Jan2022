using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingCollectionsApp
{
    internal class Program
    {
        void UnderstandingList()
        {
            //ArrayList list = new ArrayList();
            //  list.Add(100);
            //  list.Add(30);
            //  list.Add("70");
            //  list.Add(45);
            //  list.Add("Seven");
            //  int sum = 0;
            //  foreach (var item in list)
            //  {
            //      Console.WriteLine(item);
            //      sum = sum + Convert.ToInt32(item);
            //  }
            List<int> list = new List<int>();
            list.Add(100);
            list.Add(30);
            list.Add(70);
            list.Add(45);
            list.Add(7);
            int sum = 0;
            foreach (var item in list)
            {
                Console.WriteLine(item);
                sum = sum + Convert.ToInt32(item);
            }
            Console.WriteLine("Item in 3rd position " + list[2]);
        }

        void UnderstandingStack()
        {
            Stack<string> names = new Stack<string>();
            names.Push("Tim");
            names.Push("Jim");
            names.Push("Kim");
            names.Push("Lim");
            foreach (var item in names)
                Console.WriteLine(item);
            Console.WriteLine(names.Count);
            //Console.WriteLine(names.Pop());
            Console.WriteLine(names.Peek());
            Console.WriteLine(names.Count);
        }
        void UnderstandingDictionary()
        {
            Dictionary<int, string> users = new Dictionary<int, string>();
            users.Add(101, "Tim");
            users.Add(102, "Lim");
            users.Add(103, "Kim");
            users.Add(104, null);
            foreach (var item in users.Keys)
                Console.WriteLine(item + " " + users[item]);
            if (users.ContainsKey(104))
                Console.WriteLine("Key 104 already present");
            Console.WriteLine(users.ContainsValue("Jim"));
        }


        static void Main(string[] args)
        {
            new Program().UnderstandingList();
            new Program().UnderstandingStack();
            new Program().UnderstandingDictionary();
            Console.ReadKey();
        }
    }
}
