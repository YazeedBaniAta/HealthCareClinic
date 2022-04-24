using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class PartnersSection
    {
        public decimal Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
