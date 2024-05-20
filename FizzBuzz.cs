using System;

namespace CodePuzzle
{
    // Write an application to print out the numbers from 1 to 100 except;
    //
    // 1. When the number is divisible by 3 print "Fizz" in place of the number
    // 2. When the number is divisible by 5 print "Buzz" in place of the number
    // 3. When the number is divisible by 3 AND 5 print "FizzBuzz" in place of the number

    internal class FizzBuzz : iCodePuzzle
    {
        public void run()
        {
            int start = 1;
            int end = 100;

            for (int i = start; i <= end; i++)
            {
                bool divisibleByThree = i % 3 == 0;
                bool divisibleByFive = i % 5 == 0;

                if (divisibleByThree && divisibleByFive)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (divisibleByThree)
                {
                    Console.WriteLine("Fizz");
                }
                else if (divisibleByFive)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
