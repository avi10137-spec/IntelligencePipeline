using IntelligencePipeline.models.reports;
using System;
using IntelligencePipeline.Models.Enums;



namespace IntelligencePipeline.Validation
{
    public abstract class BaseValidator
    {
        //public  ValidationResult Validate(Report report)
        //{
          
        //}
     public ValidationResult ValidateCommonFields(Report report)
        {
            double LowLatitude = 29.5000;
            double HighLatitude = 33.5000;
            double LowLongitude = 34.0000;
            double HighLongitude = 36.0000;

            if (report is not SoldierReport soldierReport)
            {
                return ValidationResult.Failure(" is not solidier report");
            }

            if (report.TimeStemp > DateTime.Now || report.TimeStemp < new DateTime(2020, 1, 1))
            {
                return ValidationResult.Failure("");
            }
            if (report.Latitude < LowLatitude || report.Latitude > HighLatitude)
            {
                return ValidationResult.Failure("latitude isinvalid");
            }

            if (report.Longitude < LowLongitude || report.Longitude > HighLongitude)
            {
                return ValidationResult.Failure("longitude isinvalid");
            }
            if (string.IsNullOrEmpty(report.Description) ||report.Description.Length < 10 || report.Description.Length > 500)
            {
                return ValidationResult.Failure("description is invalid");
            }
            if (Enum.IsDefined(typeof(ReportStatus), report.Status))
            {
                return ValidationResult.Failure("status is invalid");
            }
            return ValidationResult.Success();
        }
        public abstract ValidationResult ValidateSpecificFields(Report report);


    }
}
