using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Users")] // Указываем, что эта модель соответствует таблице Users в БД
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        [Display(Name = "Email")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Хеш пароля")]
        public string PasswordHash { get; set; }

        [StringLength(20)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Роль")]
        public string Role { get; set; } // Admin, Teacher, Student, Parent

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Дата обновления")]
        public DateTime? UpdatedAt { get; set; }

        [StringLength(255)]
        [Display(Name = "ФИО родителя")]
        public string ParentName { get; set; }

        [StringLength(255)]
        [Display(Name = "Специализация")]
        public string Specialization { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; } = true;

        // Навигационные свойства
        public virtual ICollection<Circle> TeacherCircles { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            TeacherCircles = new List<Circle>();
            Registrations = new List<Registration>();
            Notifications = new List<Notification>();
        }
    }
}