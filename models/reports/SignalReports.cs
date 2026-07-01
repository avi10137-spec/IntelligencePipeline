using IntelligencePipeline.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IntelligencePipeline.models.reports
{
    class SignalReport : Report
    {
        int ScoreBase = 5;
        int minSignalStrength = -40;
        int maxSignalStrength = -70;
        int badSignalStrength = -100;
        string[] keywords = { "attack", "target", "border", "vehicle" };
        private double _frequency;
        private string _content;
        private Language _language;
        private int _signalStrength;
        public double Frequency { get; protected set; }
        public string Content { get; protected set; }
        public Language Language { get; protected set; }
        public int SignalStrength { get; protected set; }
        public SignalReport(int reportId, DateTime timestamp, double latitude,

        double longitude, string description,
        double frequency, string content, Language language,
        int signalStrength)
        : base(reportId, timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }
        public override string GetSourceType() => "Signal";
        public override int CalculateReliabilityScore()
        {
            if (SignalStrength >= minSignalStrength)
            {
                ScoreBase += 3;
            }
            else if (SignalStrength >= maxSignalStrength)
            {
                ScoreBase += 2;
            }
            else if (SignalStrength < badSignalStrength)
            {
                ScoreBase -= 2;
            }
            for (int i = 0; i < keywords.Length; i++)
            {
                if (Description.Contains(keywords[i]))
                {
                    ScoreBase += 1;
                }

            }
            return ScoreBase;
        }
    }
}