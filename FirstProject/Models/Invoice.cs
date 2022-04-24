using System;
using System.Collections.Generic;

#nullable disable

namespace FirstProject.Models
{
    public partial class Invoice
    {
        public decimal Id { get; set; }
        public string CardNumber { get; set; }
        public decimal? BookingAmount { get; set; }
        public string BookingDate { get; set; }
        public decimal? PatientId { get; set; }
        public decimal? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
