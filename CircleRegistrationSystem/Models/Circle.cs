using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Circles")]
    public class Circle
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        public int AgeMin { get; set; }

        [Required]
        public int AgeMax { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public int MaxParticipants { get; set; }

        public int CurrentParticipants { get; set; }

        [Required]
        public Guid? TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Participant Teacher { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [StringLength(500)]
        public string ImagePath { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        // Новые поля для требований
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public int MaxRegistrationsPerUser { get; set; } = 1;
        public bool AllowRegistrationEdit { get; set; } = true;
        public int EditDeadlineDays { get; set; } = 7;



        public Circle()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            RegistrationStartDate = DateTime.Now;
            RegistrationEndDate = DateTime.Now.AddMonths(1);
            Registrations = new List<Registration>();
            Schedules = new List<Schedule>();
        }
    }
}