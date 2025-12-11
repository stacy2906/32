using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Schedules")]
    public class Schedule
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CircleId { get; set; }

        [ForeignKey("CircleId")]
        public virtual Circle Circle { get; set; }

        [Required]
        [Range(1, 7)]
        public int DayOfWeek { get; set; } // 1-7 (Monday-Sunday)

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [StringLength(100)]
        public string Room { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Schedule()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}