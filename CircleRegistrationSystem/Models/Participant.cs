using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Users")] // Важно: таблица называется Users в БД
    public class Participant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } // Admin, Teacher, Student, Parent

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string ParentName { get; set; }

        [StringLength(100)]
        public string Specialization { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        // Конструктор
        public Participant()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}