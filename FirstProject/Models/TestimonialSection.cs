using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Models
{
    public partial class TestimonialSection
    {
        public decimal Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public decimal? PatientId { get; set; }
        public string Status { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
