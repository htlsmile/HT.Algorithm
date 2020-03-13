using System;
using System.Numerics;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{9}! = {Factorial(9)}");
            Console.WriteLine();
            Console.WriteLine($"Fibonacci({9}) = {Fibonacci(9)}");
            Console.WriteLine();
            Hanoi(3, "A", "B", "C");
            Console.WriteLine();
            Console.ReadKey(true);
        }

        static BigInteger Factorial(BigInteger integer)
        {
            if (integer == 0)
            {
                return 1;
            }
            else if (integer == 1)
            {
                return 1;
            }
            else
            {
                return integer * Factorial(integer - 1);
            }
        }

        static BigInteger Fibonacci(BigInteger index)
        {
            if (index == 1 || index == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(index - 1) + Fibonacci(index - 2);
            }
        }

        static void Hanoi(BigInteger count, string current, string transfer, string destination)
        {
            if (count == 1)
            {
                Console.WriteLine($"Move disc from {current} to {destination}");
            }
            else
            {
                Hanoi(count - 1, current, destination, transfer);
                Hanoi(1, current, transfer, destination);//Console.WriteLine($"Move disc from {current} to {destination}");
                Hanoi(count - 1, transfer, current, destination);
            }
        }
    }
}
