using System;
using IntelligencePipeline.models.reports;
namespace IntelligencePipeline.Validation
{
public class ValidationResult
    {
        private bool _isValid;
        private string _errorMassage;
        public bool IsValid { get; }
        public string ErrorMessage { get; }
        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }
        public static ValidationResult Success()
        {
            return new ValidationResult(true ,"");
        }
        public static ValidationResult Failure(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }



    }
}