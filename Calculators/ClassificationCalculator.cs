using IntelligencePipeline.models.reports;
using IntelligencePipeline.Models.Enums;
using System;
namespace IntelligencePipeline.Calculators;

public class ClassificationCalculator
{
    string[] topsecretKeywords = { "target","attack","missile" };
    string[] secret = { "weapon", "border" };
    private bool ContainsKeyword(string text, params string[] keywords)
    {
        if (string.IsNullOrEmpty(text))
        {
            return false;
        }
        string lowerText = text.ToLower();
        foreach (string word in keywords)
        {
            if (lowerText.Contains(word.ToLower()))
            {
                return true;
            }
        }
        return false;
    }

    public Classification Calculate(Report report)
    {
        if (report.Priority == Priority.Critical)
        {
            return Classification.TopSecret;
        }
        if (report.GetSourceType() == "Signal")
        {
            SignalReport signalTopSecret = (SignalReport)report;

            if (ContainsKeyword(signalTopSecret.Content, topsecretKeywords))
                 {
                return Classification.TopSecret;
            }
        }
        if(report.Priority == Priority.High || 
            report.GetSourceType() == "Signal"
            || ContainsKeyword(report.Description , secret))
            {
            return Classification.Secret;
        }
        if (report.Priority == Priority.Medium
            || report.GetSourceType() == "Soldier")
        {
            return Classification.Restricted;
        }
        else return Classification.Unclassified;
    }

    

}
