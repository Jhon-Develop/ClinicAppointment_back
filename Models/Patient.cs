using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Models
{
    [Table("patients")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("document")]
        public string Document { get; set; }

        [Required]
        [Column("phone")]
        public string Phone { get; set; }

        [Required]
        [Column("address")]
        public string Address { get; set; }
        
        [Required]
        [Column("date_born")]
        public DateOnly DateBorn { get; set; }

        [Required]
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}