using System;
using System.Linq;

namespace CodePuzzle
{
    // Write an application that receives three integer inputs
    // for the lengths of the sides of a triangle
    // and returns one of four values to determine the triangle type.
    //
    // 1. Scalene
    // 2. Isosceles
    // 3. Equilateral
    // 4. Error

    internal class Triangle : iCodePuzzle
    {
        public void run()
        {
            const int totalSides = 3;
            int[] lengths = new int[totalSides];
            int sideNumber = 1;

            for (int i = 0; i < totalSides; i++, sideNumber++)
            {
                int inputLength = 0;
                bool validInput = false;

                while (!validInput)
                {
                    Console.WriteLine($"Enter the length for side {sideNumber}");
                    validInput = int.TryParse(Console.ReadLine(), out inputLength);

                    if (!validInput)
                    {
                        Console.WriteLine("Invalid length input");
                    }
                }

                lengths[i] = inputLength;
            }


            if (lengths.Distinct().Count() == 1)
            {
                Console.WriteLine("Equilateral");
            }
            else if (lengths.Distinct().Count() == 2)
            {
                Console.WriteLine("Isosceles");
            }
            else if (isValidTriangle(lengths[0], lengths[1], lengths[2]))
            {
                Console.WriteLine("Scalene");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        private bool isValidTriangle(int s1, int s2, int s3)
        {
            return s1 + s2 > s3
                && s2 + s3 > s1
                && s3 + s1 > s2;
        }
    }
}
