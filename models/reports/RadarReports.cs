using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace IntelligencePipeline.models.reports
{
    class RadarReport : Report
    {   
        int ScoreBase = 6;
        int lowDistance = 500;
        int highDstance = 30000;
        int LowSpeed = 10;
        int highSpeed = 900;
        int badDistance = 70000;
        int badSpeed = 1500;

        private int _speed;
        private int _direction;
        private int _distance;
        public int Speed { get; protected set; }
        public int Direction { get; protected set; }
        public int Distance { get; protected set; }
        public RadarReport(int reportId, DateTime timestamp, double latitude,

        double longitude, string description,
        int speed, int direction, int distance)
        : base(reportId, timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }
        public override string GetSourceType() => "Radar";
        public override int CalculateReliabilityScore()
        {
          if(Distance > lowDistance && Distance < highDstance)
            {
                ScoreBase += 2;
            }
          else if (Distance > badDistance)
            {
                ScoreBase -= 2;
            }
          if (Speed > LowSpeed && Speed < highSpeed)
            {
                ScoreBase += 1;
            }
          else if (Speed > badSpeed)
            {
                ScoreBase -= 2; 
            }
            return ScoreBase;
        }
        

    }
}