using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class Solution
    {
        int number1, number2, number3;
        int tempnum1, tempnum2, tempnum3;

        void TakeNumbers(int numAmount)
        {
            if (numAmount > 0 && numAmount <=3)
            {
                Console.WriteLine("Please enter the first number");
                while (!int.TryParse(Console.ReadLine(), out tempnum1) || tempnum1 < 0)
                    Console.WriteLine("Please enter a positve number (integer)");
                number1 = tempnum1;

                if (numAmount > 1)
                {
                    Console.WriteLine("Please enter the second number");
                    while (!int.TryParse(Console.ReadLine(), out tempnum2) || tempnum2 < 0)
                        Console.WriteLine("Please enter a positve number (integer)");
                    number2 = tempnum2;

                    if (numAmount > 2)
                    {
                        Console.WriteLine("Please enter third number");
                        while (!int.TryParse(Console.ReadLine(), out tempnum3) || tempnum3 < 0)
                            Console.WriteLine("Please enter a positve number (integer)");
                        number3 = tempnum3;
                    }
                }
            }

            else
                Console.WriteLine("Please choose only upto 3 numbers");
        }

        //1) Write a program that will take an input from user as number and print all the numbers
        //from 0 to the given number.
        public void PrintOrderNumber()
        {
            TakeNumbers(1);
            for (int i = 0; i <= number1; i++)
            {
                Console.WriteLine(i);
            }
        }

        //2) Create a program that will find out if the given number is odd or even
        public void OddOrEven()
        {
            TakeNumbers(1);
            if (number1%2 == 0)
                Console.WriteLine("The number: " + number1 + " is Even");
            else
                Console.WriteLine("The number: " + number1 + " is Odd");
        }

        //3) Create a program that will take 2 numbers and find out the greates of the 2
        public void GreaterNumberForTwo()
        {
            TakeNumbers(2);

            if (number1 > number2)
                Console.WriteLine("The number: " + number1 + " is greater than the number: " + number2);
            else if (number1 == number2)
                Console.WriteLine("Both number are equal");
            else
                Console.WriteLine("The number: " + number2 + " is greater than the number: " + number1);
        }

        //4) Improve the program written in question 3 to find the greatest of 3 numbers
        public void GreaterNumberForThree()
        {
            TakeNumbers(3);

            if (number1 > number2)
            {
                if (number1 > number3)
                    Console.Write("The first number: " + number1 + " is the greatest among the three numbers");
                else
                    Console.Write("The third number: " + number3 + " is the greatest among the three numbers");
            }
            else if (number2 > number3)
                Console.Write("The second number: " + number2 + " is the greatest among the three numbers");
            else
                Console.Write("The third number: " + number3 + " is the greatest among the three numbers");
        }

        //5) Take the minimum and maximum number from user and find all numbers inbetween
        public void PrintInBetweenNumbers()
        {
            TakeNumbers(2);

            if (number1 > number2)
            {
                Console.WriteLine("------");
                for (int i = number2 + 1; i < number1; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("------");
                for (int i = number1 + 1; i < number2; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }

        //6) Find if a given number is prime
        public void IsPrime()
        {
            TakeNumbers(1);
            bool isPrime = true;

            if (number1 < 0 || number1 == 0 || number1 == 1)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= number1 / 2; i++)
                {
                    if (number1 % i == 0)
                    {
                        isPrime = false;
                    }
                    else
                        isPrime = true;
                }
            }

            if (isPrime == true)
                Console.WriteLine("The number: " + number1 + " is a prime number");
            else
                Console.WriteLine("The number: " + number1 + " is NOT a prime number");
        }

        //7) Improve the program in 5 to find all the prime numbers between the given numbers
        public void PrintInBetweenPrimeNumbers()
        {
            TakeNumbers(2);

            if (number1 > number2)
            {
                Console.WriteLine("------");
                for (int inp2 = number2 + 1; inp2 < number1; inp2++)
                {
                    bool isPrime = true;
                    if (inp2 < 0 || inp2 == 0 || inp2 == 1)
                    {
                        isPrime = false;
                    }
                    else
                    {
                        for (int i = 2; i <= inp2 / 2; i++)
                        {
                            if (inp2 % i == 0)
                            {
                                isPrime = false;
                            }

                        }
                        if (isPrime == true)
                            Console.WriteLine(inp2);
                    } 
                }
            }
            else
            {
                Console.WriteLine("------");
                for (int inp1 = number1 + 1; inp1 < number2; inp1++)
                {
                    bool isPrime = true;
                    if (inp1 < 0 || inp1 == 0 || inp1 == 1)
                    {
                        isPrime = false;
                    }
                    else
                    {
                        for (int i = 2; i <= inp1 / 2; i++)
                        {
                            if (inp1 % i == 0)
                            {
                                isPrime = false;
                            }

                        }
                        if (isPrime == true)
                            Console.WriteLine(inp1);
                    }
                }
            }
        }

        //8) Take input from user until the user enters a negative number and find the sum of all the numbers
        //that are divisible by 7
        public void PrintNumbersDivisibleBySeven()
        {
            int number1 = 0, sum = 0;

            Console.WriteLine("Please enter the first number");
            while (!int.TryParse(Console.ReadLine(), out tempnum1))
                Console.WriteLine("Please enter a positve number (integer)");
            number1 = tempnum1;

            while (number1 >= 0)
            {
                if (number1 % 7 == 0)
                    sum = sum + number1;

                Console.WriteLine("Please enter a number");
                number1 = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("The total number that is divisible by 7 is " + sum);
        }

        //9) Take a 4 digit number from user and find the sum of all the digits
        //example - 1234 result should be 10
        public void SumOfAllDigits()
        {

            Console.WriteLine("Please enter the number");
            while (!int.TryParse(Console.ReadLine(), out tempnum1) || tempnum1 < 999 || tempnum1 > 9999)
                Console.WriteLine("Please enter a 4 digit number (integer)");
            number1 = tempnum1;

            int sum = 0;

            for (int n = number1; n > 0; sum += n % 10, n /= 10) ;
            Console.WriteLine(sum);
        }

        //10) Take a 4 digit number from user and find if it is a palindrome or not
        //example - 1234 result should be Not a plaindrome
        //example - 1221 result should be Plaindrome
        public void IsPalindrome()
        {
            Console.WriteLine("Please enter the number");
            while (!int.TryParse(Console.ReadLine(), out tempnum1) || tempnum1 <999 || tempnum1 >9999)
                Console.WriteLine("Please enter a 4 digit number (integer)");
            number1 = tempnum1;

            int tempValue = number1;
            int reverse = 0;
            while (tempValue > 0)
            {
                reverse = reverse * 10 + tempValue % 10;
                tempValue = tempValue / 10;
            }

            if (reverse == number1)
                Console.WriteLine("The number:" + number1 + "is a palindrome");
            else
                Console.WriteLine("The number:" + number1 + "is NOT a palindrome");
        }

    }
}
