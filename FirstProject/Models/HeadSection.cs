using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class HeadSection
    {
        public decimal Id { get; set; }
        public string ClinicName { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicEmail { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
