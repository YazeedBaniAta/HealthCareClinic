using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FirstProject.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Doctors = new HashSet<Doctor>();
        }

        public decimal Id { get; set; }
        [Required(ErrorMessage = "Please enter Specialization Name.")]
        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
