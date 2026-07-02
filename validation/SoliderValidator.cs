using System;
using IntelligencePipeline.models.reports;

namespace IntelligencePipeline.Validation
{
    public class SoldierValidator :BaseValidator
    {
        public override ValidationResult ValidateSpecificFields(Report report)
        {
            int LowConfidencel = 1;
            int HighConfidencel = 5;
            if (report.GetSourceType() != "Soldier")
            {
                return ValidationResult.Failure("is not solider report");
            }
            SoldierReport soldierReport = (SoldierReport)report;

            if (soldierReport.SoldierName.Length < 2 || soldierReport.SoldierName.Length >50)
            {
                return ValidationResult.Failure("");
            }

            if ( soldierReport.SoldierID.Length != 7)
            {
                return ValidationResult.Failure("");
            }
            if (soldierReport.Unit.Length < 2 || soldierReport.Unit.Length > 50)
            {
                return ValidationResult.Failure("invalid unit");
            }
            if (soldierReport.ConfidenceLevel < LowConfidencel || soldierReport.ConfidenceLevel > HighConfidencel)
            {
                return ValidationResult.Failure("invalid confidencel");
            }
          
            return ValidationResult.Success();
        }
    }
}
