using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace frameQuest.Models
{
    public class Argomento
    {
        [Key]
        public int IdArgomento { get; set; }
        [Required]
        [Display(Description = "Argomento")]
        public string Nome { get; set; }
    }

    public class Fase
    {
        [Key]
        public int IdFase { get; set; }
        [Required]
        [Display(Description = "Fase")]
        public string Nome { get; set; }
    }

}