//using IntelligencePipeline.models.reports;
//using IntelligencePipeline.Models.Enums;
//using IntelligencePipeline.Validation;
//using System;
//using System.ComponentModel.DataAnnotations;
//namespace IntelligencePipeline.Pipeline
//{
  
//    public void ProcessReport(Report report)
//    {
//        report.Status = ReportStatus.Validating;

        
//        IValidator validator = GetValidatorForReport(report);

      
//        ValidationResult result = validator.Validate(report);

       
//        if (!result.IsValid)
//        {
//            report.Status = ReportStatus.Rejected;
          
//        else
//        {
//            report.Status = ReportStatus.Validated;
          
//        }
//    }
//}