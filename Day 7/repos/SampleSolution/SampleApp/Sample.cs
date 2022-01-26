using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    internal class Sample
    {
        //public delegate void SampleDelegate(int n1,int n2);
        public delegate void SampleDelegate<T>(T n1, T n2);
        public SampleDelegate<int> MyDel;
        public SampleDelegate<string> MyStringDel;
        public Sample()
        {
            //MyDel = new SampleDelegate(Add);
            MyDel = delegate (int n1, int n2)
            {
                Console.WriteLine("The sum is " + (n1 + n2));
            };
            //MyDel += Product;
            //MyDel += delegate (int n1, int n2)
            //{
            //    Console.WriteLine("The product is " + (n1 * n2));
            //};
            MyDel += (n1, n2) => Console.WriteLine("The product is " + (n1 * n2));
            MyStringDel = new SampleDelegate<string>(Add);
        }
        void Add(int num1,int num2)
        {
            int sum = num1+ num2;
            Console.WriteLine("The sum is "+sum);
        }
        void Add(string num1, string num2)
        {
            string sum = num1 + num2;
            Console.WriteLine("The result is " + sum);
        }
        //void Product(int num1, int num2)
        //{
        //    int sum = num1 * num2;
        //    Console.WriteLine("The product is " + sum);
        //}

    }
}
