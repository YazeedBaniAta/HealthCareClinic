using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Users = new HashSet<User>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Phone.")]
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
