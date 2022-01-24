using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6SolutionApp
{
    class Solution
    {
        public static int getDigit(int number)
        {
            if (number < 9)
                return number;
            return number / 10 + number % 10;
        }

        public void IsCreditNumber()
        {
            long number1;

            Console.WriteLine("Please enter the number");
            while (!long.TryParse(Console.ReadLine(), out number1) || number1.ToString().Length != 16 )
                Console.WriteLine("Please enter a 16 digit number (integer)");

            long reverse1 = 0;
            int sumEven = 0;
            int sumOdd = 0;
            int totalSum = 0;

            while (number1 > 0)
            {
                reverse1 = reverse1 * 10 + number1 % 10;
                number1 = number1 / 10;
            }
            
            String numEven = reverse1 + "";
            for (int i = 15; i >= 0; i -= 2)
                sumEven += getDigit(int.Parse(numEven[i] + "") * 2);

            String numOdd = reverse1 + "";
            for (int i = 14; i >= 0; i -= 2)
                sumOdd += int.Parse(numOdd[i] + "");

            totalSum = sumOdd + sumEven;

            if ((totalSum) % 10 == 0)
                Console.WriteLine("Valid Card");
            else
                Console.WriteLine("Invalid Card");
        }

        public void NonRepeatingNumber()
        {
            int[] numbers = new int[11];

            Console.WriteLine("Please enter 11 numbers");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Enter {0} number", i+1);
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("First unique number among the numbers is: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                int j;
                for (j = 0; j < numbers.Length; j++)
                    if (i != j && numbers[i] == numbers[j])
                        break;

                if (j == numbers.Length)
                    Console.WriteLine(numbers[i]);
            }
        }
    }
}
