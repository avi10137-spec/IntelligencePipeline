using IntelligencePipeline.models.reports;
using System;
using IntelligencePipeline.Models.Enums;




   

    namespace IntelligencePipeline.Validation
    {
        public abstract class BaseValidator : IValidator
        {
            public ValidationResult ValidateCommonFields(Report report)
            {
                double LowLatitude = 29.5000;
                double HighLatitude = 33.5000;
                double LowLongitude = 34.0000;
                double HighLongitude = 36.0000;

                if (report.TimeStemp > DateTime.Now || report.TimeStemp < new DateTime(2020, 1, 1))
                {
                    return ValidationResult.Failure("Timestamp is invalid");
                }
                if (report.Latitude < LowLatitude || report.Latitude > HighLatitude)
                {
                    return ValidationResult.Failure("Latitude is invalid");
                }
                if (report.Longitude < LowLongitude || report.Longitude > HighLongitude)
                {
                    return ValidationResult.Failure("Longitude is invalid");
                }
                if (string.IsNullOrEmpty(report.Description) || report.Description.Length < 10 || report.Description.Length > 500)
                {
                    return ValidationResult.Failure("Description is invalid");
                }
                if (!Enum.IsDefined(typeof(ReportStatus), report.Status))
                {
                    return ValidationResult.Failure("Status is invalid");
                }

                return ValidationResult.Success();
            }

            public abstract ValidationResult ValidateSpecificFields(Report report);

            public ValidationResult Validate(Report report)
            {
                ValidationResult commonResult = ValidateCommonFields(report);
                if (!commonResult.IsValid)
                {
                    return commonResult;
                }

                return ValidateSpecificFields(report);
            }
        }
    }
