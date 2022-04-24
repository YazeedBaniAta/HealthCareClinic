using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Models
{
    public partial class PatientsVesa
    {
        public decimal Id { get; set; }
        public decimal? Balance { get; set; }
        public decimal? PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
