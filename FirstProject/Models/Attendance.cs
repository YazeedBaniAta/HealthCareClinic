using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public string Status { get; set; }
        public string AttendanceDate { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
