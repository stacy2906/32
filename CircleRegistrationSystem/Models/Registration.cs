using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Registrations")]
    public class Registration
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ParticipantId { get; set; }

        [ForeignKey("ParticipantId")]
        public virtual Participant Participant { get; set; }

        [Required]
        public Guid CircleId { get; set; }

        [ForeignKey("CircleId")]
        public virtual Circle Circle { get; set; }

        public DateTime ApplicationDate { get; set; }
        public DateTime? ApprovalDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } // "Pending", "Approved", "Rejected", "Cancelled", "Active", "Inactive"

        public string RejectionReason { get; set; }
        public Guid? ApprovedBy { get; set; }
        public Guid? RejectedBy { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string AttendanceStatus { get; set; } // "Present", "Absent", "Excused"

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Registration()
        {
            Id = Guid.NewGuid();
            ApplicationDate = DateTime.Now;
            Status = "Pending";
            CreatedAt = DateTime.Now;
        }
        // Добавьте в Models/Registration.cs или создайте отдельный файл
        public class RegistrationWithDetails : Registration
        {
            public string ParticipantName { get; set; }
            public string CircleName { get; set; }
            public string ParticipantEmail { get; set; }
            public string CircleCategory { get; set; }
            public decimal CirclePrice { get; set; }
            public string TeacherName { get; set; }
        }
    }
}