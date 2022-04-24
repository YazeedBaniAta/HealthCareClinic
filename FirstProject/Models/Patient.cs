using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            Invoices = new HashSet<Invoice>();
            PatientsVesas = new HashSet<PatientsVesa>();
            TestimonialSections = new HashSet<TestimonialSection>();
            Users = new HashSet<User>();
        }

        public decimal Id { get; set; }
        
        [Required(ErrorMessage = "Please enter your First Name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your Last Name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your Email.")]
        [EmailAddress(ErrorMessage = "Please Enter valid e-mail address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Gender.")]
        public string Gender { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your Phone.")]
        [MaxLength(10)]
        [MinLength(10)]
        [Phone]
        public string Phone { get; set; }
        
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Please enter your Birth Of Date.")]
        public string Bod { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PatientsVesa> PatientsVesas { get; set; }
        public virtual ICollection<TestimonialSection> TestimonialSections { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
