using API.DTOs;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public String FirstName { get; set; } = String.Empty;

        public String? SecondName { get; set; }

        [Required]
        public String LastName { get; set; } = String.Empty;

        public String? SecondLastName { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        public Decimal Salary { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        [Required]
        public DateTime DateUpdate { get; set; }
    }
}
