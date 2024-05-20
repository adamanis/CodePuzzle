using System;
namespace CodePuzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            iCodePuzzle[] puzzles = { 
                new LinkedList(),
                new Triangle(),
                new ReverseWords(), 
                new FizzBuzz(),
            };

            bool exitProgram = false;
            while (!exitProgram) 
            {
                bool validPuzzleNumber = AskPuzzleNumber(in puzzles, out int testNumber, ref exitProgram);
                
                if (!validPuzzleNumber)
                {
                    Console.WriteLine("Invalid puzzle number");
                }
                else 
                { 
                    puzzles[testNumber].run();
                    Console.WriteLine("End of puzzle");
                }

                Console.WriteLine();
            }
        }

        static bool AskPuzzleNumber(in iCodePuzzle[] puzzles, out int puzzleNumber, ref bool isExit)
        {
            for (int i = 0; i < puzzles.Length; i++)
            {
                var test = puzzles[i];
                Console.WriteLine($"{i+1} => {test.GetType()}");
            }

            Console.Write("Enter puzzle number to run or empty to exit:");

            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) 
            {
                isExit = true;
            }
            

            bool isNumInput = int.TryParse(input, out puzzleNumber);

            puzzleNumber -= 1;

            return isNumInput && puzzleNumber < puzzles.Length && puzzleNumber > -1;

        }
    }
}
