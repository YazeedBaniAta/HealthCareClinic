using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class FeaturesSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TimesunWed { get; set; }
        public string TimethuFri { get; set; }
        public string TimesatSun { get; set; }
        public string EmaegencyCase { get; set; }
    }
}
