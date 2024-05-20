using System;

namespace CodePuzzle
{
    // Write an application to reverse the words in a string,
    //
    // for example, "cat and dog"
    // becomes "tac dna god"

    internal class ReverseWords : iCodePuzzle
    {
        public void run()
        {
            Console.Write("Enter text to reverse: ");

            string testInput = Console.ReadLine();

            Console.WriteLine(reversedText(testInput));
        }

        string reversedText(string text)
        {
            string reverse = "";
            string currentWord = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    currentWord = currentWord + text[i];
                    reverse = reverse + currentWord;
                    currentWord = "";
                }
                else
                {
                    currentWord = text[i] + currentWord;
                }
            }

            return reverse + currentWord;
        }
    }
}
