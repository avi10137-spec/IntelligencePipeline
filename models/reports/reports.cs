using IntelligencePipeline.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace IntelligencePipeline.models.reports
{
    public abstract class Report
    {
        DateTime startTime = new DateTime(2020, 01, 01);
        private int _reportId;
        private DateTime _timestamp;
        private double _latitude;
        private double _longitude;
        private string _description;
        private ReportStatus _status;
        private Priority _priority;
        private Classification _classification;
        private int _reliabilityScore;
        private string _rejectionReason;

        public int ReportId { get; protected set; }
        public DateTime TimeStemp { get; protected set; }
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
        public string Description { get; protected set; }
        public ReportStatus Status { get; set; }
        public Priority Priority { get; set; }
        public Classification Classification { get; set; }
        public int ReliabilityScore { get; set; }
        public string RejectionReason { get; set; }
        protected Report(int reportId, DateTime timestamp, double latitude,

         double longitude, string description)
        {
            ReportId = reportId;
            TimeStemp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = ReportStatus.New;

        }
        public abstract string GetSourceType();
        public abstract int CalculateReliabilityScore();
        public virtual string GetSummary()
        {
            return "";

        }
        public override string ToString()
        {
            return $" report id is {ReportId} | timesstemp is {TimeStemp} latitude is {Latitude}" +
                $" longtiud is {Longitude} description is {Description} status is {Status}";
        }



    }
}

