using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Models.DTOs
{
    public class PatientDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "name must be 100 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "name must be 150 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        public string Document { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "name must be 100 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "name must be 150 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Date-Born")]
        public DateOnly DateBorn { get; set; }
    }
}