using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment_3
{
    public class CricketTeam
    {
        public (int, double) PointCalculation(int no_of_matches)
        {
            List<int> scores = new List<int>();
            Console.WriteLine();
            Console.WriteLine("Enter the scores at per match:");
            Console.WriteLine();
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Score of Match{i + 1}: ");
                scores.Add(Convert.ToInt32(Console.ReadLine()));
            }
            int sum = scores.Sum();
            double avg = (double)scores.Average();
            return (sum, avg);
        }
    }
    public class Ipl
    {
        public static void Main(string[] args)
        {
            CricketTeam cricketTeam = new CricketTeam();

            Console.WriteLine("==== Welcome to IPL Tournament ====");
            Console.WriteLine();

            Console.Write("Enter the number of Matches Played by the team: ");
            int matches = Convert.ToInt32(Console.ReadLine());

            var (scores, avg) = cricketTeam.PointCalculation(matches);
            Console.WriteLine();

            Console.WriteLine($"The Total number of Matches Played: {matches}");
            Console.WriteLine($"The Total Scores of the Team : {scores}");
            Console.WriteLine($"The Average Score of the Team : {avg}");

            Console.WriteLine("===============================================");
        }
    }
}
