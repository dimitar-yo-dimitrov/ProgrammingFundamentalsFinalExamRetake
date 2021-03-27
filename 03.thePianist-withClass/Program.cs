using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.thePianist_withClass
{
    class PieceInfo
    {
        public string Composer { get; set; }

        public string Key { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PieceInfo> pieces = new Dictionary<string, PieceInfo>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] date = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                pieces.Add(date[0], new PieceInfo { Composer = date[1], Key = date[2] });
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] tokens = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Add")
                {
                    if (pieces.ContainsKey(tokens[1]))
                    {
                        Console.WriteLine($"{tokens[1]} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(tokens[1], new PieceInfo { Composer = tokens[2], Key = tokens[3] });

                        Console.WriteLine($"{tokens[1]} by {tokens[2]} in {tokens[3]} added to the collection!");
                    }
                }

                else if (command == "Remove")
                {
                    if (pieces.ContainsKey(tokens[1]))
                    {
                        pieces.Remove(tokens[1]);

                        Console.WriteLine($"Successfully removed {tokens[1]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {tokens[1]} does not exist in the collection.");
                    }
                }

                else if (command == "ChangeKey")
                {
                    if (pieces.ContainsKey(tokens[1]))
                    {
                        pieces[tokens[1]].Key = tokens[2];

                        Console.WriteLine($"Changed the key of {tokens[1]} to {tokens[2]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {tokens[1]} does not exist in the collection.");
                    }
                }
            }

            pieces = pieces
                .OrderBy(p => p.Key)
                .ThenBy(p => p.Value.Composer)
                .ToDictionary(k => k.Key, k => k.Value);

            //var result = pieces
            //    .OrderBy(p => p.Key)
            //    .ThenBy(p => p.Value.Composer);

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}
