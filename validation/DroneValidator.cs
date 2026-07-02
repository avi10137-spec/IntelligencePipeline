using IntelligencePipeline.models.reports;
using System;
namespace IntelligencePipeline.Validation
{
    public class DroneValidator : BaseValidator
    {
        public override ValidationResult ValidateSpecificFields(Report report)
        {
            int LowAltitude = 100;
            int HighAltitude = 10000;
            int LowImageQuality = 1;
            int HighImageQuality = 100;
            if (report.GetSourceType() != "Drone")
            {
                return ValidationResult.Failure(" is not drone report");
            }
            DroneReport dronereport = (DroneReport)report;

            if (dronereport.Altitude < LowAltitude || dronereport.Altitude > HighAltitude)
            {
                return ValidationResult.Failure("altitude is invalid");
            }
            if (dronereport.ImageQuality < LowImageQuality || dronereport.ImageQuality > HighAltitude)
            {
                return ValidationResult.Failure("image quality is invalid");
            }
            return ValidationResult.Success();
        }
    }
}