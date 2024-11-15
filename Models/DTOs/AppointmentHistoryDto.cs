using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Models.DTOs
{
    public class AppointmentHistoryDto
    {
        [Required]
        [Display(Name = "Id Appointment")]
        public int AppointmentId { get; set; }

        [Required]
        [Display(Name = "Date-Appointment-History")]
        public DateOnly Date { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "name must be 100 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        [Display(Name = "Action")]
        public string Action { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "name must be 200 characters or less")]
        [MinLength(3, ErrorMessage = "name must be at least 3 characters")]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}