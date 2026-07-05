using IntelligencePipeline.models.reports;
using IntelligencePipeline.Models.Enums;
using System;
using System.Net.NetworkInformation;

namespace IntelligencePipeline.Storage
{
class ReportRepository
    {
      private List<Report> _reports;
      
        public ReportRepository()
        {
            _reports = new List <Report> ();
        }
        public void Add(Report report)
        {
            _reports.Add(report);

        }
        bool ContainsKeyword(string text, string keyword)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keyword))
            {
                return false;
            }
            return text.ToLower().Contains(keyword.ToLower());
        }
        public List<Report> GetAll()
        {
            return _reports;
        }
        public List <Report> GetByStatus(ReportStatus status)
        {
            List<Report> ListByStatus = new List<Report>();
          foreach( Report report in _reports)
            {
              if (report.Status == status)
                {
                    ListByStatus.Add(report);
                }
            }
            return ListByStatus;
        }
        public List<Report> GetByPriority(Priority priority)
        {
            List<Report> ListByPriority = new List<Report>();
            foreach (Report report in _reports)
            {
                if (report.Priority == priority)
                {
                    ListByPriority.Add(report);
                }
            }
            return ListByPriority;
        }
        public List<Report> Search(string keyword)
        {
            List <Report> ListBySearch = new List <Report>();
          foreach(Report report in _reports)
            {
                if (ContainsKeyword(report.Description, keyword))
                {
                    ListBySearch.Add(report);
                }
            }
            return ListBySearch;
        }
        public Report GetById(int reportId)
        {
            foreach(Report report in _reports)
            {
                if(report.ReportId == reportId)
                {
                    return report;
                }
            }
            return null;

        }
        public void UpdateStatus(int reportId, ReportStatus newStatus)
        {
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                {
                    report.Status = newStatus;
                }
            }
        }
        public int GetTotalCount()
        {
            return _reports.Count;
        }
        public int GetCountByStatus(ReportStatus status)
        {
            int countByStatus = 0;
            foreach (Report report in _reports)
            {
                if(report.Status == status)
                {
                    countByStatus++;
                }

            }
            return countByStatus;
        }




    }
}