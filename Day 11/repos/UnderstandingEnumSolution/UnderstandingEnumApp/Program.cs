using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingEnumApp
{
    //An enumeration type (or enum type) 
    //is a value type defined by a set of named constants of the underlying integral numeric type.
    enum Planets
    {
        Mercury, 
        Venus, 
        Earth, 
        Mars, 
        Jupiter, 
        Saturn, 
        Uranus, 
        Neptune, 
        Pluto
    }

    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    [Flags]
    public enum Days
    {
        None = 0,
        Monday = 1, // 1
        Tuesday = 2,  // 2
        Wednesday = 4,  // 4
        Thursday = 8,  // 8
        Friday = 16, // 16
        Saturday = 32, // 32
        Sunday = 64, // 64
        Weekend = Saturday | Sunday
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Planets.Earth + " is a Planet");
            Console.WriteLine(Planets.Earth + " is Planet no " + (int)Planets.Earth);

            Console.WriteLine("------------------");

            Season a = Season.Autumn;
            Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2

            var b = (Season)1;
            Console.WriteLine(b);  // output: Summer

            var c = (Season)4;
            Console.WriteLine(c);  // output: 4

            Console.WriteLine("------------------");

            Season e = Season.Spring | Season.Autumn;
            Console.WriteLine(e);

            Days d = Days.Monday | Days.Tuesday;
            Console.WriteLine(d);

            Console.WriteLine("------------------");

            Console.WriteLine((Season)1);
            Console.WriteLine((Season)2);
            Console.WriteLine((Season)3);
            Console.WriteLine((Season)4);

            Console.ReadKey();
        }
    }
}
