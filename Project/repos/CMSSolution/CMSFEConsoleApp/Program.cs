using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSModelsLibrary;

namespace CMSFEConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageUser program = new ManageUser();

            program.RegisterAndDisplayUser();

            Console.ReadKey();
        }
    }
}
