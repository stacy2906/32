using System;
using System.Collections.Generic;

namespace CircleRegistrationSystem.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual List<Circle> Circles { get; set; }

        public Teacher()
        {
            Id = Guid.NewGuid();
            Circles = new List<Circle>();
        }
    }
}