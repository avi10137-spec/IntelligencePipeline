using IntelligencePipeline.Calculators;
using IntelligencePipeline.models.reports;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.storage;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using System;

namespace IntelligencePipeline.Pipeline
{
    public class ReportPipline
    {
        private ReportRepository _validatedReports;
        private RejectedReportRepository _rejectedReports;
        private int _nextReportId;

        public ReportPipline()
        {
            _validatedReports = new ReportRepository();
            _rejectedReports = new RejectedReportRepository();
            _nextReportId = 1;

        }
         IValidator GetValidatorForReport(Report report)
        {
            if (report is DroneReport)
            {
                return new DroneValidator();
            }
            if (report is SoldierReport)
            {
                return new SoldierValidator();
            }
            if (report is RadarReport)
            {
                return new RadarValidator();
            }
            if (report is SignalReport)
            {
                return new SignalValidator();
            }
            throw new ArgumentException("Unknown report type");

        }
        public int getId()
        {
            return _nextReportId;
        }
        public void ProcessReport(Report report)
        {
            report.Status = ReportStatus.Validating;

            IValidator validator = GetValidatorForReport(report);

            ValidationResult result = validator.Validate(report);

           
            if (!result.IsValid)
            {
                report.Status = ReportStatus.Rejected;
                report.RejectionReason = result.ErrorMessage;
                _rejectedReports.Add(report);
                return;
            }
            else
            {
                report.Status = ReportStatus.Validated;
                _nextReportId++;
                report.CalculateReliabilityScore();
                ReliabilityCalculator reliabilitycal = new ReliabilityCalculator();
                reliabilitycal.Calculate(report);
                PriorityCalculator prioritycal = new PriorityCalculator();
                report.Priority = prioritycal.Calculate(report);
                ClassificationCalculator classification = new ClassificationCalculator();
                report.Classification = classification.Calculate(report);
                _validatedReports.Add(report);






            }
        }

      


           
            }
        }
    
