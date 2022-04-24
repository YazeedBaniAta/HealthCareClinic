using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class Department
    {
        public Department()
        {
            Appointments = new HashSet<Appointment>();
            Doctors = new HashSet<Doctor>();
        }

        public decimal Id { get; set; }
        [Required(ErrorMessage = "Please enter The Clinic Name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter The Clinic Description.")]
        public string Description { get; set; }

        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please enter The Clinic Image.")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
