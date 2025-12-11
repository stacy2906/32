using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Attendances")]
    public class Attendance
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RegistrationId { get; set; }

        [ForeignKey("RegistrationId")]
        public virtual Registration Registration { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } // "Present", "Absent", "Late", "Excused"

        public string Notes { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }

        public Attendance()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now.Date;
            CreatedAt = DateTime.Now;
        }
    }
}