using System;
using System.Collections.Generic;
using System.Linq;
using CircleRegistrationSystem.Models;

namespace CircleRegistrationSystem.Services
{
    public class CircleService
    {
        private readonly DatabaseService _db;

        public CircleService(DatabaseService db)
        {
            _db = db;
        }

        public List<Circle> GetAvailableCircles()
        {
            try
            {
                return _db.GetCircles();
            }
            catch
            {
                return new List<Circle>();
            }
        }

        public List<Circle> SearchCircles(string keyword = null, string category = null,
     int? minAge = null, int? maxAge = null, decimal? maxPrice = null)
        {
            try
            {
                var circles = _db.GetCircles().AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                    circles = circles.Where(c =>
                        c.Name.ToLower().Contains(keyword.ToLower()) ||
                        (c.Description != null && c.Description.ToLower().Contains(keyword.ToLower())));

                if (!string.IsNullOrEmpty(category) && category != "Все")
                    circles = circles.Where(c => c.Category == category);

                if (minAge.HasValue)
                    circles = circles.Where(c => c.AgeMin <= minAge.Value);

                if (maxAge.HasValue)
                    circles = circles.Where(c => c.AgeMax >= maxAge.Value);

                if (maxPrice.HasValue)
                    circles = circles.Where(c => c.Price <= maxPrice.Value);

                return circles.ToList();
            }
            catch
            {
                return new List<Circle>();
            }
        }
        public List<Circle> GetTeacherCircles(Guid teacherId)
        {
            try
            {
                return _db.GetCircles()
                    .Where(c => c.TeacherId == teacherId && c.IsActive)
                    .ToList();
            }
            catch
            {
                return new List<Circle>();
            }
        }
        public Circle GetCircleById(Guid id)
        {
            try
            {
                return _db.GetCircleById(id);
            }
            catch
            {
                return null;
            }
        }
    }
}