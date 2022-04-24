using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FirstProject.Models
{
    public partial class Attendance
    {
        public decimal Id { get; set; }
        public decimal? DoctorId { get; set; }
        public string Status { get; set; }
        public string AttendanceDate { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
