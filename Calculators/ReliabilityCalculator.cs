using IntelligencePipeline.models.reports;
using System;
namespace IntelligencePipeline.Calculators;
public class ReliabilityCalculator
{
    public int Calculate(Report report)
    {
        int totalScore = report.ReliabilityScore;
        if (totalScore > 10)
        {
            return 10;
        }

        return totalScore;

    }

} 