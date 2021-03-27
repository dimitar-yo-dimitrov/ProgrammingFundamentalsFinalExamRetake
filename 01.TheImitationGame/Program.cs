using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Decode")
                {
                    break;
                }

                string[] tokens = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Move")
                {
                    int characterCount = int.Parse(tokens[1]);
                    string characters = text.Substring(0, characterCount);
                    text = text.Substring(characterCount) + characters;
                }

                else if (command == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string character = tokens[2];

                    text = text.Insert(index, character);
                }

                else if (command == "ChangeAll")
                {
                    string oldLetter = tokens[1];
                    string newLetter = tokens[2];

                    foreach (var character in text)
                    {
                        text = text.Replace(oldLetter, newLetter);
                    }
                }
            }

            Console.WriteLine($"The decrypted message is: {text}");
        }
    }
}
