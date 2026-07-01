//using System;
//namespace IntelligencePipeline.Validation
//{
//    using global::IntelligencePipeline.models.reports;
//    using IntelligencePipeline.Models.Reports;
//    using System;
//    using System.ComponentModel.DataAnnotations;

//    namespace IntelligencePipeline.Validation
//    {
//        public class SoldierValidator : IValidator // המימוש של הממשק (מקור: 255)
//        {
//            public ValidationResult Validate(Report report)
//            {
//                // א. וידוא שהדיווח הוא אכן של חייל והסבת הטיפוס (מקור: 260)
//                if (report is not SoldierReport soldierReport)
//                {
//                    return ValidationResult.Failure("הדיווח שסופק אינו דיווח חייל תקין.");
//                }

//                // ב. בדיקת השדות הכלליים (שמגיעים מאב הדיווח) (מקור: 260)
//                if (soldierReport.Timestamp > DateTime.Now || soldierReport.Timestamp < new DateTime(2020, 1, 1)) // (מקור: 102, 103)
//                {
//                    return ValidationResult.Failure("תאריך הדיווח לא תקין.");
//                }

//                if (string.IsNullOrEmpty(soldierReport.Description) || soldierReport.Description.Length < 10) // (מקור: 108)
//                {
//                    return ValidationResult.Failure("התיאור קצר מדי.");
//                }

//                // ג. בדיקת שדות ייחודיים של חייל (מקור: 259, 260)
//                // בדיקה ששם החייל לא ריק
//                if (string.IsNullOrWhiteSpace(soldierReport.SoldierName))
//                {
//                    return ValidationResult.Failure("שם החייל אינו יכול להיות ריק.");
//                }

//                // בדיקה שתעודת החייל מכילה בדיוק 7 ספרות (לפי חוקי הארכיטקטורה)
//                if (string.IsNullOrEmpty(soldierReport.SoldierID) || soldierReport.SoldierID.Length != 7)
//                {
//                    return ValidationResult.Failure("מזהה חייל חייב להכיל 7 תווים בדיוק.");
//                }

//                // אם הכל תקין, מחזירים הצלחה! (מקור: 258)
//                return ValidationResult.Success();
//            }
//        }
//    }
//}