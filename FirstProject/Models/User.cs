using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FirstProject.Models
{
    public partial class User
    {
        public decimal Id { get; set; }

        [Required(ErrorMessage = "Please Enter The Email.")]
        [EmailAddress(ErrorMessage = "Please Enter valid e-mail address.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter The Password.")]
        public string Password { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? AdminId { get; set; }
        public decimal? DoctorId { get; set; }
        public decimal? PatientId { get; set; }
        

        public virtual Admin Admin { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Role Role { get; set; }

        
    }
}
