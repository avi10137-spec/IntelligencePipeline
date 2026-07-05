using IntelligencePipeline.models.reports;
using IntelligencePipeline.Models.Enums;
using System;
namespace IntelligencePipeline.Calculators;

public class PriorityCalculator
{
    string[] criticalKeywords = { "missile", "explosion", "attack", "fire" };
    string[] highKeywords = { "weapon", "suspicious", "border" };
    string[] mediumKeywords = { "movement", "vehicle", "activity" };
    string[] criticalKeywordForSignal = { "target", "attack" };
    public bool ContainsKeyword(string text, string[] keywords)
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
       bool ContainsKeyword(string text, string keyword)
        {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keyword))
        {
            return false;
        }
        return text.ToLower().Contains(keyword.ToLower());
    }

    public Priority Calculate(Report report)
    {
        if (ContainsKeyword(report.Description, criticalKeywords))
        {
            return Priority.Critical;
        }

        if (report.GetSourceType() == "Radar")
        {
            RadarReport radarreport = (RadarReport)report;
            if (radarreport.Speed >= 800)
            {
                return Priority.Critical;
            }
        }
        return Priority.Critical;

        if (report.GetSourceType() == "Radar")
        {
            RadarReport radarCritical = (RadarReport)report;
            if (radarCritical.Speed >= 800)
            {
                return Priority.Critical;
            }
        }

        if (report.GetSourceType() == "Signal")
        {
            SignalReport signalCritical = (SignalReport)report;
            if (ContainsKeyword(signalCritical.Content, criticalKeywordForSignal[0]) &&
                ContainsKeyword(signalCritical.Content, criticalKeywordForSignal[1]))
            {
                return Priority.Critical;
            }
        }

        if (ContainsKeyword(report.Description, highKeywords))
        {
            return Priority.High;
        }

        if (report.GetSourceType() == "Drone")
        {
            DroneReport droneHigh = (DroneReport)report;
            if (droneHigh.Altitude < 500)
            {
                return Priority.High;
            }
        }

        if (report.GetSourceType() == "Radar")
        {
            RadarReport radarHigh = (RadarReport)report;
            if (radarHigh.Speed >= 400)
            {
                return Priority.High;
            }
        }

        if (report.GetSourceType() == "Soldier")
        {
            SoldierReport soldierHigh = (SoldierReport)report;
            if (soldierHigh.ConfidenceLevel >= 4 &&
              ContainsKeyword(soldierHigh.Description, mediumKeywords[0]))
            {
                return Priority.High;
            }
        }

        if (ContainsKeyword(report.Description, mediumKeywords))
        {
            return Priority.Medium;
        }

        if (report.GetSourceType() == "Radar")
        {
            RadarReport radarMedium = (RadarReport)report;
            if (radarMedium.Speed >= 120)
            {
                return Priority.Medium;
            }
        }

        if (report.ReliabilityScore >= 7)
        {
            return Priority.Medium;
        }

        return Priority.Low;
    }
}