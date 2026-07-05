using IntelligencePipeline.models.reports;
using System;
namespace IntelligencePipeline.Calculators;
public class ReliabilityCalculator
{
    public  void Calculate(Report report)
    {
        int totalScore = report.ReliabilityScore;
        if (totalScore > 10)
        {
            totalScore = 10;
        }
        if (totalScore < 1)
        {
            totalScore = 1;
        }

        report.ReliabilityScore = totalScore;
       



    }

} 