using System;
using System.Collections.Generic;
using System.Linq;
using CircleRegistrationSystem.Models;

namespace CircleRegistrationSystem.Services
{
    public class ReportService
    {
        private readonly DatabaseService _db;

        public ReportService(DatabaseService db)
        {
            _db = db;
        }

        public class CircleStatistics
        {
            public string CircleName { get; set; }
            public string Category { get; set; }
            public int MaxParticipants { get; set; }
            public int CurrentParticipants { get; set; }
            public int AvailableSlots { get; set; }
            public decimal FillPercentage { get; set; }
            public int PendingRegistrations { get; set; }
            public int ApprovedRegistrations { get; set; }
            public int TotalRegistrations { get; set; }
        }

        public class FinancialReport
        {
            public string CircleName { get; set; }
            public decimal Price { get; set; }
            public int Participants { get; set; }
            public decimal TotalRevenue { get; set; }
            public int PaidParticipants { get; set; }
            public decimal ReceivedRevenue { get; set; }
        }

        public List<CircleStatistics> GetCirclesStatistics()
        {
            var circles = _db.Circles
                .Include("Registrations")
                .Where(c => c.IsActive)
                .ToList();

            var statistics = new List<CircleStatistics>();

            foreach (var circle in circles)
            {
                var registrations = circle.Registrations.ToList();
                var approvedCount = registrations.Count(r => r.Status == "Approved");
                var pendingCount = registrations.Count(r => r.Status == "Pending");

                var stat = new CircleStatistics
                {
                    CircleName = circle.Name,
                    Category = circle.Category,
                    MaxParticipants = circle.MaxParticipants,
                    CurrentParticipants = circle.CurrentParticipants,
                    AvailableSlots = circle.MaxParticipants - circle.CurrentParticipants,
                    FillPercentage = circle.MaxParticipants > 0 ?
                        (decimal)circle.CurrentParticipants / circle.MaxParticipants * 100 : 0,
                    PendingRegistrations = pendingCount,
                    ApprovedRegistrations = approvedCount,
                    TotalRegistrations = registrations.Count
                };

                statistics.Add(stat);
            }

            return statistics.OrderByDescending(s => s.FillPercentage).ToList();
        }

        public List<FinancialReport> GetFinancialReport(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _db.Circles
                .Include("Registrations")
                .Include("Registrations.Payments")
                .Where(c => c.IsActive && c.Price > 0);

            if (startDate.HasValue)
                query = query.Where(c => c.CreatedAt >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(c => c.CreatedAt <= endDate.Value);

            var circles = query.ToList();
            var reports = new List<FinancialReport>();

            foreach (var circle in circles)
            {
                var approvedRegistrations = circle.Registrations
                    .Where(r => r.Status == "Approved")
                    .ToList();



                var report = new FinancialReport
                {
                    CircleName = circle.Name,
                    Price = circle.Price,
                    Participants = approvedRegistrations.Count,
                    TotalRevenue = circle.Price * approvedRegistrations.Count,
            
                };

                reports.Add(report);
            }

            return reports.OrderByDescending(r => r.TotalRevenue).ToList();
        }

        public Dictionary<string, int> GetRegistrationsByCategory()
        {
            var result = new Dictionary<string, int>();
            var groups = _db.Circles
                .Include("Registrations")
                .Where(c => c.IsActive)
                .GroupBy(c => c.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Sum(c => c.Registrations.Count)
                })
                .ToList();

            foreach (var group in groups)
            {
                result[group.Category] = group.Count;
            }

            return result;
        }

        public Dictionary<string, int> GetRegistrationsByStatus()
        {
            var result = new Dictionary<string, int>();
            var groups = _db.Registrations
                .GroupBy(r => r.Status)
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .ToList();

            foreach (var group in groups)
            {
                result[group.Status] = group.Count;
            }

            return result;
        }

        public List<KeyValuePair<string, int>> GetTopCircles(int top = 10)
        {
            var circles = _db.Circles
                .Include("Registrations")
                .Where(c => c.IsActive)
                .Select(c => new
                {
                    CircleName = c.Name,
                    RegistrationsCount = c.Registrations.Count
                })
                .OrderByDescending(x => x.RegistrationsCount)
                .Take(top)
                .ToList();

            var result = new List<KeyValuePair<string, int>>();
            foreach (var circle in circles)
            {
                result.Add(new KeyValuePair<string, int>(circle.CircleName, circle.RegistrationsCount));
            }

            return result;
        }

        public int GetTotalParticipants()
        {
            return _db.Users.Count();
        }

        public int GetActiveCirclesCount()
        {
            return _db.Circles.Count(c => c.IsActive);
        }

        public int GetTotalRegistrations()
        {
            return _db.Registrations.Count();
        }

        public decimal GetTotalRevenue()
        {
            var revenue = _db.Circles
                .Include("Registrations")
                .Where(c => c.IsActive)
                .ToList()
                .Sum(c => c.Price * c.Registrations.Count(r => r.Status == "Approved"));

            return revenue;
        }
    }
}