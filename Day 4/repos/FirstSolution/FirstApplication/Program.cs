using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    internal class Program //ctor double tab
    {
        void PrintName() //Method Defination
        {
            Console.WriteLine("Hello Halim"); //cw double tab
        }

        void PrintAnyName(string name)
        {
            Console.WriteLine("Hello " + name);
        }

        void Greet(string greet)
        {
            string name;
            Console.WriteLine("Please enter your name");
            name = Console.ReadLine();
            Console.WriteLine(greet + " " + name);
        }
        static void Main(string[] args)
        {
            //Program program = new Program();
            //program.PrintName(); //Method Call
            //program.PrintAnyName("Halim");
            //program.Greet("hi");

            //Calculator calc = new Calculator();
            //calc.Add();
            //calc.Product();

            //Statements s = new Statements();
            //s.UnderstandingSelectionWithIf();
            //s.UnderstandingSelectionWithSwitch();
            //s.IterationWithFor();
            //s.IterationWithWhile();
            //s.IterationWithDoWhile();

            //Solution solution = new Solution();
            //solution.PrintOrderNumber();
            //solution.OddOrEven();
            //solution.GreaterNumberForTwo();
            //solution.GreaterNumberForThree();
            //solution.PrintInBetweenNumbers();
            //solution.IsPrime();
            //solution.PrintInBetweenPrimeNumbers();
            //solution.PrintNumbersDivisibleBySeven();
            //solution.SumOfAllDigits();
            //solution.IsPalindrome();

            string s = "The answer is " + 5.ToString();
            // Outputs: "The answer is 5"
            Console.WriteLine(s);

            Type type = 12345.GetType();
            // Outputs: "System.Int32"
            Console.WriteLine(type);

            Console.ReadKey();
        }
    }
}
