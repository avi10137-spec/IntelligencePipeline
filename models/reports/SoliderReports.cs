using IntelligencePipeline.models.reports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace IntelligencePipeline.models.reports
{
    class SoldierReport : Report
    {

        string[] keywords = { "weapon", "vehicle", "movement", "expolosion" };
        private string _solidierName;
        private string _soldierId;
        private string _unit;
        private int _confidencelevel;
        public string SoldierName { get; protected set; }
        public string SoldierID { get; protected set; }
        public string Unit { get; protected set; }
        public int ConfidenceLevel { get; protected set; }
        public SoldierReport(int reportId, DateTime timestamp, double latitude,

         double longitude, string description,
          string soldierName, string soldierID, string unit,

         int confidenceLevel) : base(reportId, timestamp, latitude, longitude, description)
        {
            SoldierName = soldierName;
            SoldierID = soldierID;
            Unit = unit;
            ConfidenceLevel = confidenceLevel;

        }
        public override string GetSourceType() => "Soldier";
        public override int CalculateReliabilityScore()
        {
            int ScoreBase = 4;
            ScoreBase += ConfidenceLevel;
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
