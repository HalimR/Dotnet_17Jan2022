using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSystemApp
{
    public class Example
    {
        public int value;

        public Example(int value)
        {
            this.value = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Example first = new Example(7);
            Example second = first;
            
            second.value = 5;

            int number1 = 7;
            int number2 = number1;
            number2 = 5;

            Console.WriteLine("First class value " + first.value);
            Console.WriteLine("Second class value " + second.value);

            Console.WriteLine("First number " + number1);
            Console.WriteLine("Second number " + number2);

            Console.ReadKey();

        }
    }
}
