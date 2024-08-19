using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Attendances = new HashSet<Attendance>();
            Invoices = new HashSet<Invoice>();
            Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First Name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last Name.")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please enter Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Phone.")]
        [MaxLength(10)]
        [MinLength(10)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter Birth Of Date.")]
        public string Bod { get; set; }
        public string IsAvailable { get; set; }
        public string AvailableTime { get; set; }
        public string AvailableDay { get; set; }
        [Required(ErrorMessage = "Please enter The Salary.")]
        public string Salary { get; set; }
        [Required(ErrorMessage = "Please enter Clinc.")]
        public int? DepartmentId { get; set; }
        [Required(ErrorMessage = "Please enter Specialization For doctor.")]
        public int? SpecializationId { get; set; }
        
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


        public virtual Department Department { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
