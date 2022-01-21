using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstadingArraysApplication
{
    class Program
    {
        void UnderstandingBasicArray()
        {
            int[] arrNumbers = new int[3];
            Console.WriteLine("Please enter the numbers");
            for (int i = 0; i < arrNumbers.Length; i++)
            {
                arrNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < arrNumbers.Length; i++)
            {
                Console.WriteLine(arrNumbers[i]);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.UnderstandingBasicArray();
            Console.ReadKey();
        }
    }
}
