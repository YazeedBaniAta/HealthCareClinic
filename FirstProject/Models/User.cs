using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter The Email.")]
        [EmailAddress(ErrorMessage = "Please Enter valid e-mail address.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter The Password.")]
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int? AdminId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        

        public virtual Admin Admin { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Role Role { get; set; }

        
    }
}
