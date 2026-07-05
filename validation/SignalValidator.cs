using IntelligencePipeline.models.reports;
using IntelligencePipeline.Models.Enums;
using System;
namespace IntelligencePipeline.Validation
{
    public class SignalValidator : BaseValidator
    {
        public override ValidationResult ValidateSpecificFields(Report report)
        {
            double LowFrequncy = 1.0;
            double HigFrequncy = 3000.0;
            int LowSignalSrench = -120;
            int HighSignalSrench = 0;
            if (report.GetSourceType() != "Signal")
            {
                return ValidationResult.Failure(" is not signal report");
            }
            SignalReport signalReport = (SignalReport)report;
            if (signalReport.Frequency < LowFrequncy || signalReport.Frequency > HigFrequncy)
            {
                return ValidationResult.Failure("invalid");
            }
            if (signalReport.Content.Length < 5 || signalReport.Content.Length > 1000)
            {
                return ValidationResult.Failure("invalid");
            }
            if (signalReport.SignalStrength < LowSignalSrench || signalReport.SignalStrength > HighSignalSrench)
            {
                return ValidationResult.Failure("invalid");
            }
            if (Enum.IsDefined(typeof(Language), signalReport.Language))
            {
                return ValidationResult.Failure("invalid language");
            }
            else return ValidationResult.Success();
        }
    }
}