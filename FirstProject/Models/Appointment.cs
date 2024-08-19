using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Choose Appointment Date.")]
        public DateTime? AppointmentDate { get; set; }
        [Required(ErrorMessage = "Please Choose Appointment Time.")]
        public string AppointmentTime { get; set; }
        public string Message { get; set; }
        [Required(ErrorMessage = "Please Select The Clinic.")]
        public int? DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Choose The Doctor.")]
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public string Status { get; set; }

        public virtual Department Department { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
