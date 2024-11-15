using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("date")]
        public DateOnly Date { get; set; }

        [Required]
        [Column("reason")]
        public string Reason { get; set; }

        [Required]
        [Column("notes")]
        public string Notes { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Required]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Required]
        [Column("specialty_id")]
        public int SpecialtyId { get; set; }

        [Required]
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [ForeignKey("SpecialtyId")]
        public Specialty Specialty { get; set; }

    }
}