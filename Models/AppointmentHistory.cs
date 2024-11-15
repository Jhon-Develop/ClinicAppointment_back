using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Models
{
    [Table("appointment_histories")]
    public class AppointmentHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("appointment_id")]
        public int AppointmentId { get; set; }

        [Required]
        [Column("date")]
        public DateOnly Date { get; set; }

        [Required]
        [Column("action")]
        public string Action { get; set; }

        [Required]
        [Column("remarks")]
        public string Remarks { get; set; }

        [Required]
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
    }
}