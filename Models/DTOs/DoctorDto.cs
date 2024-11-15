using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Models.DTOs
{
    public class DoctorDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "name must be 100 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "name must be 100 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "name must be 150 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}