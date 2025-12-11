using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Participant User { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // Registration, Approval, Rejection, Attendance, Deadline, System

        public Guid? ReferenceId { get; set; } // ID связанной записи

        public bool IsRead { get; set; } = false;

        public DateTime? ReadAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public Notification()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}