using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Your Name.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter Your Email.")]
        [EmailAddress(ErrorMessage = "Please Enter valid e-mail address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter The Topic.")]
        public string Topic { get; set; }
        [Required(ErrorMessage = "Please enter Your Phone.")]
        [MaxLength(10)]
        [MinLength(10)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter Your Massage.")]
        public string Message { get; set; }
    }
}
