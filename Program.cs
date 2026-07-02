using IntelligencePipeline.models.reports;
using System;
 

namespace IntelligencePipeline
{
    class Program
    {
        static void Main() {

            SoldierReport a = new SoldierReport(3, DateTime.Now, 10.0, 50.0, "weapon weapon is critical movement", "david", "818", "8200", 3);
            RadarReport b = new RadarReport(4, DateTime.Now, 15.0, 80.0, "weapon weapon is critical movement", 150, 200, 500);

            Console.WriteLine($"{ a.SoldierName} ");
            Console.WriteLine($"{a.GetSourceType()}");


            int score = a.CalculateReliabilityScore();
            Console.WriteLine($" {score}");
            Console.WriteLine($"{b.Distance} ");


            string type = a.ToString();
            string type1 = b.ToString();
            Console.WriteLine(type);
            Console.WriteLine(type1);
            int score1 = b.CalculateReliabilityScore();
            Console.WriteLine($"{score1}");
        }
        }
    }
