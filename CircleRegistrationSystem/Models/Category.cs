using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CircleRegistrationSystem.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public Category()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}