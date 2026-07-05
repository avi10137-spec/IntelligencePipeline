using System;
using IntelligencePipeline.models.reports;
using IntelligencePipeline.Models.Enums;
namespace IntelligencePipeline.storage
{
    class RejectedReportRepository
    {
        private List<Report> _rejectedReports;

        public RejectedReportRepository()
        {
            _rejectedReports = new List<Report>();
        }
        bool ContainsKeyword(string text, string keyword)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keyword))
            {
                return false;
            }
            return text.ToLower().Contains(keyword.ToLower());
        }
        public void Add(Report report)
        {
            _rejectedReports.Add(report);
        }
        public List<Report> GetAll()
        {
            return _rejectedReports;
        }
        public int GetTotalCount()
        {
            return _rejectedReports.Count;
        }
        public List<Report> GetByReason(string reasonKeyword)
        {
            List<Report> reportByReason = new List<Report>();
            foreach (Report report in _rejectedReports)
            {
             if (ContainsKeyword(report.RejectionReason, reasonKeyword)){
                    reportByReason.Add(report);
                }
               
            }
            return reportByReason;

        }


    }


}

