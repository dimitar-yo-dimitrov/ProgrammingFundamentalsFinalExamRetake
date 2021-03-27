using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\||#)(?<name>[A-Za-z\s]+)\1(?<expirationDate>\d{2}\/\d{2}\/\d{2})(\||#)(?<colories>\d{1,4}|10000)\1");

            string date = Console.ReadLine();

            var matches = regex.Matches(date);

            int colories = matches
                .Select(m => m.Groups["colories"].Value)
                .Select(int.Parse)
                .Sum();

            Console.WriteLine($"You have food to last you for: {colories / 2000} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["name"]}, Best before: {match.Groups["expirationDate"]}, Nutrition: {match.Groups["colories"]}");
            }
        }
    }
}
