using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int result = sol.solution(1041);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }

    class Solution
    {
        public int solution(int N)
        {
            string bits = Convert.ToString(N, 2);
            int longest = 0;
            int count = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0')
                    count++;

                else
                {
                    longest = Math.Max(count, longest);
                    count = 0;
                }
            }
            return longest;
        }
    }
}
