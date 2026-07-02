using IntelligencePipeline.models.reports;
using System;
namespace IntelligencePipeline.Validation
{
    public class RadarValidator : BaseValidator
    {
        public override ValidationResult ValidateSpecificFields(Report report)
        {
            int LowSpeed = 0;
            int HighSpeed = 2000;
            int LowDirection = 0;
            int HighDirection = 360;
            int LowDistance = 100;
            int highDistance = 10000;
            if (report.GetSourceType() != "Radar")
            {
                return ValidationResult.Failure(" is not radar report");
            }
            RadarReport radarReport = (RadarReport)report;
            if (radarReport.Speed < LowSpeed || radarReport.Speed > HighSpeed)
            {
                return ValidationResult.Failure("invalid speed");
            }
            if (radarReport.Direction < LowDirection || radarReport.Direction > HighDirection)
            {
                return ValidationResult.Failure("invalid direction");
            }
            if (radarReport.Direction < LowDistance || radarReport.Distance > highDistance)
            {
                return ValidationResult.Failure("invalid distance");
            }
            return ValidationResult.Success();






        }
    }
}
