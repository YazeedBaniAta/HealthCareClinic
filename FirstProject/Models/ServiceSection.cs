using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Models
{
    public partial class ServiceSection
    {
        public decimal Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
