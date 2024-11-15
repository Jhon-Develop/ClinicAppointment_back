using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Models
{
    [Table("doctor_specialties")]
    public class DoctorSpecialty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Required]
        [Column("specialty_id")]
        public int SpecialtyId { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [ForeignKey("SpecialtyId")]
        public Specialty Specialty { get; set; }
    }
}