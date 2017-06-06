using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a word, phrase, or paragraph to be converted to PIG LATIN.");
            Console.WriteLine();
            Console.WriteLine("Please DO NOT use punctuation.");
            string userInput = Console.ReadLine();
            string pigLatin = MakePigLatin(userInput);
            Console.WriteLine(pigLatin);
        }

        static string MakePigLatin(string userInput)
        {
            const string vowels = "AEIOUaeiou";
            const string consonants = "BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz";
            List<string> pigLatinWords = new List<string>();

            foreach (string s in userInput.Split(' '))
            {
                string firstChar = s.Substring(0, 1);
                string pigLatin = s.Substring(1) + firstChar + "ay";
                int vowelIndex = vowels.IndexOf(firstChar);
                
                if (s.Length > 1)
                {
                    string firstTwoLetters = s.Substring(0, 2);
                    string secondLetter = s.Substring(1, 1);
                    string doubleConsonantPigLatin = s.Substring(2) + firstTwoLetters + "ay";
                    int doubleConsonantIndex = consonants.IndexOf(secondLetter);

                    if (vowelIndex == -1 && doubleConsonantIndex > -1)
                    {
                        pigLatinWords.Add(doubleConsonantPigLatin);
                    }
                    else if (vowelIndex == -1)
                    {
                        pigLatinWords.Add(pigLatin);
                    }
                    else if (vowelIndex > -1)
                    {
                        pigLatinWords.Add(s + "ay");
                    }
                    else
                    {
                        Console.WriteLine("Invalid. Please try again");
                    }
                }
                else
                {
                    if (vowelIndex == -1)
                    {
                        pigLatinWords.Add(pigLatin);
                    }
                    else if (vowelIndex > -1)
                    {
                        pigLatinWords.Add(s + "ay");
                    }
                    else
                    {
                        Console.WriteLine("Invalid. Please try again");
                    }
                }
            }
            return string.Join(" ", pigLatinWords);
        }
    }
}
