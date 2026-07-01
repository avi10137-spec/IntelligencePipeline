using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligencePipeline.models.reports
{
     class DroneReport : Report
    {
        int HasHighImageQuality = 80;
        int HasMediumImageQuality = 50;
        int MinOptimalAltitude = 500;
        int MaxOptimalAltitude = 3000;
        int IsAltitudeTooHigh = 7000;
        int ScoreBase = 5;
        private int _Altitude;
        private int _ImageQuality;
        public int Altitude { get; protected set; }
        public int ImageQuality { get; protected set; }
        public DroneReport(int reportId, DateTime timestamp, double latitude,
        double longitude, string description,
        int altitude, int imageQuality)
         : base(reportId, timestamp, latitude, longitude, description)
        {
            Altitude = altitude;
            ImageQuality = imageQuality;
        }
        public override string GetSourceType() => "Drone";
        public override int CalculateReliabilityScore()
        {
            
            if (ImageQuality >= HasHighImageQuality)
            {
                ScoreBase += 3;
            }
            else if(ImageQuality >= HasMediumImageQuality)
            {
                ScoreBase += 2;
            }
            if (Altitude > MinOptimalAltitude && Altitude < MaxOptimalAltitude)
            {
                ScoreBase += 2;
            }
            else if (Altitude > IsAltitudeTooHigh)
            {
                ScoreBase -= 2;
            }
            return ScoreBase;
        }





    }
}
