using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FirstProject.Models
{
    public partial class CounterSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string HappyPeopel { get; set; }
        public string SurgeryComeplet { get; set; }
        public string ExpertDoctor { get; set; }
        public string WordwideBranch { get; set; }
    }
}
