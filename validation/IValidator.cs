using IntelligencePipeline.models.reports;
using System;

namespace IntelligencePipeline.Validation
{
    interface IValidator
    {
       public ValidationResult Validate(Report report);
    }

}