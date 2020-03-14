using System;
using System.Linq;

namespace EggDrop
{
    class Program
    {
        const int maxFloor = 9;
        const int maxEgg = 9;

        static void Main(string[] args)
        {
            var line = new string('-', maxEgg * 8 + 9);
            Console.WriteLine(line);
            Console.WriteLine($"|  T\\N\t|  [{string.Join("]\t|  [", Enumerable.Range(1, maxEgg))}]\t|");
            Console.WriteLine(line);
            for (int floor = 1; floor <= maxFloor; floor++)
            {
                Console.Write($"|  ({floor})\t|");
                for (int egg = 1; egg <= maxEgg; egg++)
                {
                    Console.Write($"   {LeastTimes(floor, egg)}\t|");
                }
                Console.WriteLine();
                Console.WriteLine(line);
            }
            Console.ReadKey(true);
        }

        static int LeastTimes(int floor, int egg)
        {
            if (floor < 1)
            {
                return 0;
            }
            else if (floor == 1)
            {
                return 1;
            }
            else if (egg == 1)
            {
                return floor;
            }
            else
            {
                int result = int.MaxValue;
                for (int k = 1; k <= floor; k++)
                {
                    var Mk = Math.Max(LeastTimes(k - 1, egg - 1), LeastTimes(floor - k, egg)) + 1;
                    result = Math.Min(result, Mk);
                }
                return result;
            }
        }
    }
}
