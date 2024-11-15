using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Models.DTOs
{
    public class AppointmentDto
    {
        [Required]
        [Display(Name = "Date-Appointment")]
        public DateOnly Date { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "name must be 200 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Required]
        [MaxLength(2000, ErrorMessage = "name must be 2000 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "name must be 100 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Id Patient")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Id Doctor")]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Id Specialty")]
        public int SpecialtyId { get; set; }
    }
}