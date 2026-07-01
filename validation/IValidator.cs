using IntelligencePipeline.models.reports;
using System;
using System.ComponentModel.DataAnnotations;
namespace IntelligencePipeline.Validation
{
    interface IValidator
    {
       public ValidationResult Validate(Report report);
    }

}